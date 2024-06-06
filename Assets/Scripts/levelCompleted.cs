using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelCompleted : MonoBehaviour
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
        HideLCUI();
    }

    private void OnEnable()
    {
        GORetryButton = ui.Q<Button>("LCRetryButton");
        GORetryButton.clicked += OnLCRetryButtonClicked;

        GOMenuButton = ui.Q<Button>("LCMenuButton");
        GOMenuButton.clicked += OnLCMenuButtonClicked;

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
        audioManager.PlayGameOver(audioManager.game_over);
    }
}
