using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    private VisualElement gameOverUI;
    private Label roundsTextLabel;
    private ShopController shopController;

    void Start()
    {
        GameIsOver = false;

        var uiDocument = FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        gameOverUI = root.Q<VisualElement>("GOPanel");
        roundsTextLabel = root.Q<Label>("GORoundsSurvived");

        gameOverUI.style.display = DisplayStyle.None;

        shopController = FindObjectOfType<ShopController>();
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        roundsTextLabel.text = PlayerStats.Rounds.ToString();
        gameOverUI.style.display = DisplayStyle.Flex;
        shopController.HideShopUI();
        Time.timeScale = 0f;
    }
}
