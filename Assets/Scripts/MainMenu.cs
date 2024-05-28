using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "Wiosna";

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
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
