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

        retryButton = root.Q<Button>("RetryButton");
        menuButton = root.Q<Button>("MenuButton");

        retryButton.clicked += Retry;
        menuButton.clicked += Menu;
    }

    void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Menu()
    {
        Debug.Log("Go to menu.");
        // Tu możesz dodać kod do przejścia do menu
    }
}
