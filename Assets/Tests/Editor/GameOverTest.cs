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
    gameObject = new GameObject();
    gameOver = gameObject.AddComponent<GameOver>();

    UIDocument uiDocument = gameObject.AddComponent<UIDocument>();

    VisualElement ui = new VisualElement();
    uiDocument.rootVisualElement.Add(ui);

    gameOver.ui = ui;
}

    [Test]
    public void HideGOUITest()
    {
        gameOver.HideGOUI();

        Assert.AreEqual(DisplayStyle.None, gameOver.ui.style.display.value);
    }

    [Test]
    public void ShowGOUITest()
    {
        gameOver.ShowGOUI();

        Assert.AreEqual(DisplayStyle.Flex, gameOver.ui.style.display.value);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}
