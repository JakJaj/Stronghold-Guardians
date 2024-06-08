using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    private HashSet<string> unlockedButtons = new HashSet<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockButton(string buttonName)
    {
        if (!unlockedButtons.Contains(buttonName))
        {
            unlockedButtons.Add(buttonName);
        }
    }

    public bool IsButtonUnlocked(string buttonName)
    {
        return unlockedButtons.Contains(buttonName);
    }
}
