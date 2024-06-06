using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelCompleted : MonoBehaviour
{
    public VisualElement ui;
    public Button LCRetryButton;
    public Button LCMenuButton;
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
        HideLCUI();
    }

    private void OnEnable()
    {
        LCRetryButton = ui.Q<Button>("LCRetryButton");
        LCRetryButton.clicked += OnLCRetryButtonClicked;

        LCMenuButton = ui.Q<Button>("LCMenuButton");
        LCMenuButton.clicked += OnLCMenuButtonClicked;

        roundsSurvivedLabel = ui.Q<Label>("GORoundsSurvived");
    }

    void OnLCRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        WaveSpawner.ResetStatics();
    }

    void OnLCMenuButtonClicked()
    {
        Debug.Log("Go to menu.");
        SceneManager.LoadScene(levelToLoad);
    }

    public void HideLCUI()
    {
        ui.style.display = DisplayStyle.None;
    }

    public void ShowLCUI()
    {
        if (roundsSurvivedLabel != null && waveSpawner != null)
        {
            roundsSurvivedLabel.text = "Rounds Survived: " + waveSpawner.GetWaveIndex();
        }
        ui.style.display = DisplayStyle.Flex;

        audioManager.StopAllAudio();
        audioManager.PlayVictory(audioManager.vicotry_music);
    }
}
