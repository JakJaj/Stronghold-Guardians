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
        gameOver.HideGOUI();
        pauseMenu.HidePauseUI();
    }

    void Update()
    {
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver.ShowGOUI();
        shopController.HideShopUI();
        Time.timeScale = 0f;
    }
}
