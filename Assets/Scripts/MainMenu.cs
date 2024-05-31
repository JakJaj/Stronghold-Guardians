using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private string levelSummer = "Lato";
    private string levelAutumn = "Jesien";
    private string levelWinter = "Zima";
    private string levelSpring = "Wiosna";

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var summerButton = root.Q<Button>("MainMenuSummerButton");
        var autumnButton = root.Q<Button>("MainMenuAutumnButton");
        var winterButton = root.Q<Button>("MainMenuWinterButton");
        var springButton = root.Q<Button>("MainMenuSpringButton");
        var quitButton = root.Q<Button>("MainMenuQuitButton");

        summerButton.clicked += summerPlay;
        autumnButton.clicked += autumnPlay;
        winterButton.clicked += winterPlay;
        springButton.clicked += springPlay;

        quitButton.clicked += Quit;
    }

    public void summerPlay()
    {
        SceneManager.LoadScene(levelSummer);
        Time.timeScale = 1;
    }

    public void autumnPlay()
    {
        SceneManager.LoadScene(levelAutumn);
        Time.timeScale = 1;
    }

    public void winterPlay()
    {
        SceneManager.LoadScene(levelWinter);
        Time.timeScale = 1;
    }

    public void springPlay()
    {
        SceneManager.LoadScene(levelSpring);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
