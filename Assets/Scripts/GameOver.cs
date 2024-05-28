using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOver : MonoBehaviour
{
    private Button retryButton;
    private Button menuButton;

    void Start()
    {
        var uiDocument = FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        retryButton = root.Q<Button>("GORetryButton");
        menuButton = root.Q<Button>("GOMenuButton");

        retryButton.clicked += Retry;
        menuButton.clicked += Menu;
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }


    void Menu()
    {
        Debug.Log("Go to menu.");
    }
}
