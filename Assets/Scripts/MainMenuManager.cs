using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    private Button summerButton;
    private Button autumnButton;
    private Button winterButton;
    private Button springButton;
    private Button quitButton;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        summerButton = root.Q<Button>("MainMenuSummerButton");
        autumnButton = root.Q<Button>("MainMenuAutumnButton");
        winterButton = root.Q<Button>("MainMenuWinterButton");
        springButton = root.Q<Button>("MainMenuSpringButton");
        quitButton = root.Q<Button>("MainMenuQuitButton");

        autumnButton.SetEnabled(false);
        winterButton.SetEnabled(false);
        springButton.SetEnabled(false);
    }

    public void UnlockAutumnButton()
    {
        autumnButton.SetEnabled(true);
    }
}
