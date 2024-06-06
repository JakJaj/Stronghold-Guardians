using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private ShopController shopController;
    private GameOver gameOver;
    private PauseMenu pauseMenu;
    private WaveSpawner waveSpawner;
    private LevelCompleted levelCompleted;
    private bool hasWon = false;
    public string buttonToUnlockName;


    void Start()
    {
        Application.targetFrameRate = 60;

        waveSpawner = FindObjectOfType<WaveSpawner>();
        shopController = FindObjectOfType<ShopController>();
        gameOver = FindObjectOfType<GameOver>();
        pauseMenu = FindObjectOfType<PauseMenu>();
        levelCompleted = FindObjectOfType<LevelCompleted>();
        gameOver.HideGOUI();
        pauseMenu.HidePauseUI();
    }

    void Update()
    {
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }

        if (!hasWon && waveSpawner.AllWavesCompleted())
        {
            Victory();
            hasWon = true;
        }
    }

    void EndGame()
    {
        gameOver.ShowGOUI();
        shopController.HideShopUI();
        Time.timeScale = 0f;
    }

    void TogglePauseMenu()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pauseMenu.ShowPauseUI();
            shopController.HideShopUI();
        }
        else
        {
            pauseMenu.ResumeGame();
            shopController.ShowShopUI();
        }
    }

    void Victory()
    {
        Debug.Log("You won!");
        shopController.HideShopUI();
        levelCompleted.ShowLCUI();
        ButtonManager.instance.UnlockButton(buttonToUnlockName);
        Time.timeScale = 0f;
    }
}
