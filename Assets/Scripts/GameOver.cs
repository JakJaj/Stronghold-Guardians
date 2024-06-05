using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    public VisualElement ui;
    public Button GORetryButton;
    public Button GOMenuButton;
    public Label roundsSurvivedLabel;
    BuildManager buildManager;
    private string levelToLoad = "MainMenu";
    private WaveSpawner waveSpawner;

    AudioManager audioManager;


    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ui = root.Q<VisualElement>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        buildManager = BuildManager.instance;
        waveSpawner = FindObjectOfType<WaveSpawner>();
        HideGOUI();
    }

    private void OnEnable()
    {
        GORetryButton = ui.Q<Button>("GORetryButton");
        GORetryButton.clicked += OnGORetryButtonClicked;

        GOMenuButton = ui.Q<Button>("GOMenuButton");
        GOMenuButton.clicked += OnGOMenuButtonClicked;

        roundsSurvivedLabel = ui.Q<Label>("GORoundsSurvived");
    }

    void OnGORetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    void OnGOMenuButtonClicked()
    {
        Debug.Log("Go to menu.");
        SceneManager.LoadScene(levelToLoad);
    }

    public void HideGOUI()
    {
        ui.style.display = DisplayStyle.None;
    }

    public void ShowGOUI()
    {
        if (roundsSurvivedLabel != null && waveSpawner != null)
        {
            roundsSurvivedLabel.text = "Rounds Survived: " + waveSpawner.GetWaveIndex();
        }
        ui.style.display = DisplayStyle.Flex;

        audioManager.StopAllAudio();
        audioManager.PlayGameOver(audioManager.game_over);
    }
}
