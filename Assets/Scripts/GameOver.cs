using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public VisualElement ui;
    public Button GORetryButton;
    public Button GOMenuButton;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        HideGOUI();
    }

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ui = root.Q<VisualElement>();
    }

    private void OnEnable()
    {
        GORetryButton = ui.Q<Button>("GORetryButton");
        GORetryButton.clicked += OnGORetryButtonClicked;

        GOMenuButton = ui.Q<Button>("GORetryButton");
        GOMenuButton.clicked += OnGOMenuButtonClicked;
    }

    void OnGORetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    void OnGOMenuButtonClicked()
    {
        Debug.Log("Go to menu.");
    }

    public void HideGOUI()
    {
        ui.style.display = DisplayStyle.None;
    }

    public void ShowGOUI()
    {
        ui.style.display = DisplayStyle.Flex;
    }
}