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
    private TurretBlueprint selectedTurret;

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
        selectedTurret = weaponCannon;
        buildManager.SetTurretToBuild(selectedTurret);
    }

    private void OnButtonTwoClicked()
    {
        Debug.Log("Button Two clicked");
        selectedTurret = weaponBallista;
        buildManager.SetTurretToBuild(selectedTurret);
    }

    private void OnButtonThreeClicked()
    {
        Debug.Log("Button Three clicked");
        selectedTurret = weaponCatapult;
        buildManager.SetTurretToBuild(selectedTurret);
    }

    public void UpdateCurrentMoney()
    {
        currentMoneyLabel.text = PlayerStats.Money.ToString();
    }

    void Update()
    {
        UpdateCurrentMoney();

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Selection canceled");
            selectedTurret = null;
            buildManager.SetTurretToBuild(null);
        }
    }
}
