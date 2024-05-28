using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private VisualElement ui;
    private Button PauseContinueButton;
    private Button PauseOnRetryButtonClickedButton;
    private Button PauseMenuButton;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        HidePauseUI();
    }

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ui = root.Q<VisualElement>();
    }

    private void OnEnable()
    {
        PauseContinueButton = ui.Q<Button>("PausePauseContinueButton");
        PauseContinueButton.clicked += OnContinueButtonClicked;

        PauseOnRetryButtonClickedButton = ui.Q<Button>("PauseOnRetryButtonClickedButton");
        PauseOnRetryButtonClickedButton.clicked += OnRetryButtonClicked;

        PauseMenuButton = ui.Q<Button>("PausePauseMenuButton");
        PauseMenuButton.clicked += OnMenuButtonCLicked;
    }

    void OnContinueButtonClicked()
    {
        Time.timeScale = 1;
        ui.style.display = DisplayStyle.None;
    }

    void OnRetryButtonClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnMenuButtonCLicked()
    {
        Debug.Log("Go to OnMenuButtonCLicked.");
    }

    public void HidePauseUI()
    {
        ui.style.display = DisplayStyle.None;
    }

    public void ShowPauseUI()
    {
        ui.style.display = DisplayStyle.Flex;
    }
}
