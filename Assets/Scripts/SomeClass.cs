using UnityEngine;

public class SomeClass : MonoBehaviour
{
    public string buttonToUnlockName;
    private WaveSpawner waveSpawner;

    void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        waveSpawner.nextButtonToUnlock = buttonToUnlockName;
    }
}
