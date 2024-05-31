using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private VisualElement ui;
    private Button PauseContinueButton;
    private Button PauseOnRetryButtonClickedButton;
    private Button PauseMenuButton;
    private string levelToLoad = "MainMenu";

    BuildManager buildManager;

    void Start()
    {
        HidePauseUI();
        buildManager = BuildManager.instance;
    }

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ui = root.Q<VisualElement>();
    }

    private void OnEnable()
    {
        PauseContinueButton = ui.Q<Button>("PauseContinueButton");
        PauseContinueButton.clicked += OnContinueButtonClicked;

        PauseOnRetryButtonClickedButton = ui.Q<Button>("PauseRetryButton");
        PauseOnRetryButtonClickedButton.clicked += OnRetryButtonClicked;

        PauseMenuButton = ui.Q<Button>("PauseMenuButton");
        PauseMenuButton.clicked += OnMenuButtonClicked;
    }

    private void OnDisable()
    {
        PauseContinueButton.clicked -= OnContinueButtonClicked;
        PauseOnRetryButtonClickedButton.clicked -= OnRetryButtonClicked;
        PauseMenuButton.clicked -= OnMenuButtonClicked;
    }

    public void OnContinueButtonClicked()
    {
        ResumeGame();
    }

    public void OnRetryButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuButtonClicked()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void HidePauseUI()
    {
        ui.style.display = DisplayStyle.None;
    }

    public void ShowPauseUI()
    {
        ui.style.display = DisplayStyle.Flex;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        HidePauseUI();
    }
}
