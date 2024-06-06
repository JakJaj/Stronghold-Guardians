using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    private Button summerButton;
    private Button autumnButton;
    private Button winterButton;
    private Button springButton;
    private Button quitButton;
    public VisualElement ui;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ui = root.Q<VisualElement>();

        summerButton = root.Q<Button>("MainMenuSummerButton");
        autumnButton = root.Q<Button>("MainMenuAutumnButton");
        winterButton = root.Q<Button>("MainMenuWinterButton");
        springButton = root.Q<Button>("MainMenuSpringButton");
        quitButton = root.Q<Button>("MainMenuQuitButton");

        autumnButton.SetEnabled(false);
        winterButton.SetEnabled(false);
        springButton.SetEnabled(false);

        if (PlayerPrefs.GetInt("MainMenuAutumnButton", 0) == 1)
        {
            autumnButton.SetEnabled(true);
        }
        if (PlayerPrefs.GetInt("MainMenuWinterButton", 0) == 1)
        {
            winterButton.SetEnabled(true);
        }
        if (PlayerPrefs.GetInt("MainMenuSpringButton", 0) == 1)
        {
            springButton.SetEnabled(true);
        }
    }

    public void UnlockButton(string buttonName)
    {
        var button = ui.Q<Button>(buttonName);
        if (button != null)
        {
            button.SetEnabled(true);
        }
    }
}
