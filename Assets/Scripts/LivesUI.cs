using UnityEngine;
using UnityEngine.UIElements;

public class LivesUI : MonoBehaviour
{
    private Label livesLabel;

    // Start is called before the first frame update
    void Start()
    {
        // Pobierz UIDocument i root element
        var uiDocument = GetComponent<UIDocument>();
        var root = uiDocument.rootVisualElement;

        // Znajdź element Label o nazwie HeartAmount
        livesLabel = root.Q<Label>("ShopHeartAmount");
    }

    // Update is called once per frame
    void Update()
    {
        // Aktualizuj tekst livesLabel dynamicznie
        livesLabel.text = PlayerStats.Lives.ToString();
    }
}
