using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private VisualElement ui;
    private Button continueButton;
    private Button retryButton;
    private Button menuButton;

    void Start()
    {
        var uiDocument = FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        ui = root.Q<VisualElement>("PauseMenuPanel");

        continueButton = ui.Q<Button>("ContinueButton");
        retryButton = ui.Q<Button>("RetryButton");
        menuButton = ui.Q<Button>("MenuButton");

        continueButton.clicked += ContinueGame;
        retryButton.clicked += Retry;
        menuButton.clicked += Menu;
    }

    void ContinueGame()
    {
        Time.timeScale = 1; // Kontynuowanie gry
        ui.style.display = DisplayStyle.None;
    }

    void Retry()
    {
        Time.timeScale = 1; // Ustawienie czasu na normalny
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Menu()
    {
        Time.timeScale = 1; // Ustawienie czasu na normalny
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        Time.timeScale = 0; // Zatrzymanie gry
        ui.style.display = DisplayStyle.Flex;
    }
}
