using UnityEngine;

public class SomeClass : MonoBehaviour
{
    public string buttonToUnlockName;

    void Start()
    {
        GameManager.instance.buttonToUnlockName = buttonToUnlockName; // Ustaw odpowiednią nazwę przycisku
    }
}
