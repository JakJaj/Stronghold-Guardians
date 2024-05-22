using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    public VisualElement ui;

    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;
    public Label currentMoneyLabel;
    public Label priceOneLabel;
    public Label priceTwoLabel;
    public Label priceThreeLabel;

    public TurretBlueprint weaponCannon;
    public TurretBlueprint weaponBallista;
    public TurretBlueprint weaponCatapult;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;

        // Set the text of the price labels
        priceOneLabel.text = weaponCannon.cost.ToString();
        priceTwoLabel.text = weaponBallista.cost.ToString();
        priceThreeLabel.text = weaponCatapult.cost.ToString();
    }

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

        currentMoneyLabel = ui.Q<Label>("CurrentMoney");

        // Get references to the price labels
        priceOneLabel = ui.Q<Label>("PriceOne");
        priceTwoLabel = ui.Q<Label>("PriceTwo");
        priceThreeLabel = ui.Q<Label>("PriceThree");

        // Set the initial text of the price labels
        priceOneLabel.text = weaponCannon.cost.ToString();
        priceTwoLabel.text = weaponBallista.cost.ToString();
        priceThreeLabel.text = weaponCatapult.cost.ToString();
    }

    private void OnDisable()
    {
        buttonOne.clicked -= OnButtonOneClicked;
        buttonTwo.clicked -= OnButtonTwoClicked;
        buttonThree.clicked -= OnButtonThreeClicked;
    }

    private void OnButtonOneClicked()
    {
        Debug.Log("Button One clicked");
        buildManager.SetTurretToBuild(weaponCannon);
    }

    private void OnButtonTwoClicked()
    {
        Debug.Log("Button Two clicked");
        buildManager.SetTurretToBuild(weaponBallista);
    }

    private void OnButtonThreeClicked()
    {
        Debug.Log("Button Three clicked");
        buildManager.SetTurretToBuild(weaponCatapult);
    }

    public void UpdateCurrentMoney()
    {
        currentMoneyLabel.text = PlayerStats.Money.ToString();
    }

    void Update()
    {
        UpdateCurrentMoney();
    }
}
