using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public UIDocument shopUIDocument;
    public UIDocument gameOverUIDocument;

    private void Start()
    {
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

        gameOverUIDocument.rootVisualElement.style.display = DisplayStyle.None;
    }

    public void ShowGameOverUI()
    {
        if (shopUIDocument == null || gameOverUIDocument == null)
        {
            Debug.LogError("shopUIDocument or gameOverUIDocument is not assigned!");
            return;
        }

        shopUIDocument.rootVisualElement.style.display = DisplayStyle.None;
        gameOverUIDocument.rootVisualElement.style.display = DisplayStyle.Flex;
    }
}
