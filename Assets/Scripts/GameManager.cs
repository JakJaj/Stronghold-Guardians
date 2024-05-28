using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ShopController shopController;
    private GameOver gameOver;
    private PauseMenu pauseMenu;

    void Start()
    {
        shopController = FindObjectOfType<ShopController>();
        gameOver = FindObjectOfType<GameOver>();
        pauseMenu = FindObjectOfType<PauseMenu>();
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
        }
        else
        {
            pauseMenu.ResumeGame();
        }
    }
}
