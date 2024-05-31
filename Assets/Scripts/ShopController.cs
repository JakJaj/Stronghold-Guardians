using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    public VisualElement ui;
    private WaveSpawner waveSpawner;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;
    public Label currentMoneyLabel;
    public Label priceOneLabel;
    public Label priceTwoLabel;
    public Label priceThreeLabel;
    public Label waveCountdownLabel;
    public TurretBlueprint weaponCannon;
    public TurretBlueprint weaponBallista;
    public TurretBlueprint weaponCatapult;
    BuildManager buildManager;
    private TurretBlueprint selectedTurret;

    void Start()
    {
        buildManager = BuildManager.instance;
        waveSpawner = FindObjectOfType<WaveSpawner>();

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
        buttonOne = ui.Q<Button>("ShopButtonOne");
        buttonOne.clicked += OnButtonOneClicked;

        buttonTwo = ui.Q<Button>("ShopButtonTwo");
        buttonTwo.clicked += OnButtonTwoClicked;

        buttonThree = ui.Q<Button>("ShopButtonThree");
        buttonThree.clicked += OnButtonThreeClicked;

        currentMoneyLabel = ui.Q<Label>("ShopCurrentMoney");

        priceOneLabel = ui.Q<Label>("ShopPriceOne");
        priceTwoLabel = ui.Q<Label>("ShopPriceTwo");
        priceThreeLabel = ui.Q<Label>("ShopPriceThree");

        waveCountdownLabel = ui.Q<Label>("ShopWaveCountdownText");

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

    public void HideShopUI()
    {
        ui.style.display = DisplayStyle.None;
    }

    public void ShowShopUI()
    {
        ui.style.display = DisplayStyle.Flex;
    }

    void Update()
    {
        UpdateCurrentMoney();

        if (waveCountdownLabel != null && waveSpawner != null)
        {
            waveCountdownLabel.text = waveSpawner.GetCountdown().ToString("F2");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Selection canceled");
            selectedTurret = null;
            buildManager.SetTurretToBuild(null);
        }
    }
}
