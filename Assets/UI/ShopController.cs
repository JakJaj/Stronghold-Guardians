using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; // Upewnij się, że używasz odpowiedniego namespace

public class ShopController : MonoBehaviour
{
    public VisualElement ui;

    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;

    private void Awake()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        ui = root.Q<VisualElement>();
    }

    private void OnEnable()
    {
        buttonOne = ui.Q<Button>("ButtonOne");
        buttonOne.clicked += OnButtonOneClicked;

        buttonTwo = ui.Q<Button>("ButtonTwo");
        buttonTwo.clicked += OnButtonTwoClicked;

        buttonThree = ui.Q<Button>("ButtonThree");
        buttonThree.clicked += OnButtonThreeClicked;
    }

    private void OnDisable()
    {
        // Usuń event handlers, aby uniknąć problemów z pamięcią
        buttonOne.clicked -= OnButtonOneClicked;
        buttonTwo.clicked -= OnButtonTwoClicked;
        buttonThree.clicked -= OnButtonThreeClicked;
    }

    private void OnButtonOneClicked()
    {
        Debug.Log("Button One clicked");
    }

    private void OnButtonTwoClicked()
    {
        Debug.Log("Button Two clicked");
    }

    private void OnButtonThreeClicked()
    {
        Debug.Log("Button Three clicked");
    }
}
