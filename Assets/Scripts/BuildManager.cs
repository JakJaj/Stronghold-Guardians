using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        instance = this;
    }

    public GameObject weaponCannon;
    public GameObject weaponBallista;
    public GameObject weaponCatapult;
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (turretToBuild == null)
        {
            Debug.LogError("No turret selected to build!");
            return;
        }

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to buy that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        audioManager.PlayPlaceDefence(audioManager.place_deffence);

        Debug.Log("Turret built! Money left: " + PlayerStats.Money);

        turretToBuild = null;
    }

    public void SetTurretToBuild(TurretBlueprint turret)
    {
        if (turret == null)
        {
            return;
        }
        turretToBuild = turret;
    }
}
