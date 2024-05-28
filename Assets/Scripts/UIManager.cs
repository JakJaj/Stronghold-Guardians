using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument shopUIDocument;
    public UIDocument gameOverUIDocument;

    private void Start()
    {
        // Sprawdzenie, czy referencje są przypisane
        if (shopUIDocument == null)
        {
            Debug.LogError("shopUIDocument is not assigned!");
            return;
        }

        if (gameOverUIDocument == null)
        {
            Debug.LogError("gameOverUIDocument is not assigned!");
            return;
        }

        // Na początku ukryj gameOverUIDocument
        gameOverUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ShowGameOverUI()
    {
        // Sprawdzenie, czy referencje są przypisane
        if (shopUIDocument == null || gameOverUIDocument == null)
        {
            Debug.LogError("shopUIDocument or gameOverUIDocument is not assigned!");
            return;
        }

        // Ukryj shopUIDocument
        shopUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        // Pokaż gameOverUIDocument
        gameOverUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
