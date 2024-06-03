using NUnit.Framework;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class GameOverTests
{
    private GameOver gameOver;
    private GameObject gameObject;

[SetUp]
public void Setup()
{
    // Create a new GameObject and add the GameOver component
    gameObject = new GameObject();
    gameOver = gameObject.AddComponent<GameOver>();

    // Create a new UIDocument and add it to the GameObject
    UIDocument uiDocument = gameObject.AddComponent<UIDocument>();

    // Create a new VisualElement and add it to the root
    VisualElement ui = new VisualElement();
    uiDocument.rootVisualElement.Add(ui);

    // Set the ui field of the GameOver component
    gameOver.ui = ui;
}

    [Test]
    public void HideGOUITest()
    {
        // Call the HideGOUI method
        gameOver.HideGOUI();

        // Assert that the ui is hidden
        Assert.AreEqual(DisplayStyle.None, gameOver.ui.style.display.value);
    }

    [Test]
    public void ShowGOUITest()
    {
        // Call the ShowGOUI method
        gameOver.ShowGOUI();

        // Assert that the ui is visible
        Assert.AreEqual(DisplayStyle.Flex, gameOver.ui.style.display.value);
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameObject after each test
        Object.DestroyImmediate(gameObject);
    }
}