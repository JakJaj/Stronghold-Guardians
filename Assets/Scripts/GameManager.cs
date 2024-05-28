using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    private VisualElement gameOverUI;
    private Label roundsTextLabel;

    void Start()
    {
        GameIsOver = false;

        var uiDocument = FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        gameOverUI = root.Q<VisualElement>("MenuPanel");
        roundsTextLabel = root.Q<Label>("RoundsSurvived");

        gameOverUI.style.display = DisplayStyle.None;
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
        Time.timeScale = 0f;
    }
}
