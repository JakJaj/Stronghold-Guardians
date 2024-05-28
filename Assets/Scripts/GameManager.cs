using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private ShopController shopController;
    private GameOver gameOver;

    private PauseMenu pauseMenu;

    void Start()
    {
        shopController = FindObjectOfType<ShopController>();
        gameOver = FindObjectOfType<GameOver>();
        pauseMenu = FindObjectOfType<PauseMenu>(); // Dodaj tę linię
        gameOver.HideGOUI();
        pauseMenu.HidePauseUI(); // Zmienione na pauseMenu.HidePauseUI()
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
            Time.timeScale = 0f;
            pauseMenu.HidePauseUI();
        }
    }
}