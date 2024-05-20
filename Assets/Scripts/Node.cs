using UnityEngine;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 positionOffset;
    [Header("Optional for future")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        rend.material.color = hoverColor;

        if (!buildManager.CanBuild)
        {
            Debug.Log("You need to choose the turret first! - TODO: Display on screen.");
            return;
        }

        if (turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        rend.material.color = hoverColor;


        if (buildManager.CanBuild)
            return;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}