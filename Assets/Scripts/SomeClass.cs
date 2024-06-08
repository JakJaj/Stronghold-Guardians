using UnityEngine;

public class SomeClass : MonoBehaviour
{
    public string buttonToUnlockName;

    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.buttonToUnlockName = buttonToUnlockName;
        }
    }
}
