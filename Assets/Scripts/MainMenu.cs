using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private string levelToLoad = "Wiosna";

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var playButton = root.Q<Button>("MainMenuPlayButton");
        var quitButton = root.Q<Button>("MainMenuQuitButton");

        playButton.clicked += Play;
        quitButton.clicked += Quit;
    }

    public void Play()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
