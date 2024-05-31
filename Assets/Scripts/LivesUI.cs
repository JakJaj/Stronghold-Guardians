using UnityEngine;
using UnityEngine.UIElements;

public class LivesUI : MonoBehaviour
{
    private Label livesLabel;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        livesLabel = root.Q<Label>("ShopHeartAmount");
    }

    void Update()
    {
        livesLabel.text = PlayerStats.Lives.ToString();
    }
}
