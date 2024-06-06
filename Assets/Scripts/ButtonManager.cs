using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance; // Singleton instance

    private HashSet<string> unlockedButtons = new HashSet<string>(); // Set to store unlocked buttons

    private void Awake()
    {
        // Ensure there's only one instance of ButtonManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevent ButtonManager from being destroyed on scene load
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
