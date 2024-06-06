using UnityEngine;

public class SomeClass : MonoBehaviour
{
    public string buttonToUnlockName; // Nazwa przycisku do odblokowania
    private WaveSpawner waveSpawner;

    void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        waveSpawner.nextButtonToUnlock = buttonToUnlockName; // Ustawienie nazwy przycisku
    }
}
