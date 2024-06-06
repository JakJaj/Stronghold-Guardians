using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 3f;
    private float countdown = 5f;
    private int waveIndex = 0;
    private LevelCompleted levelCompleted;

    private void Awake()
    {
        // Znajdź komponent LevelCompleted na scenie
        levelCompleted = FindObjectOfType<LevelCompleted>();
    }

    public float GetCountdown()
    {
        return countdown;
    }

    public int GetWaveIndex()
    {
        return waveIndex;
    }

    public void SetWaveIndex(int index)
    {
        waveIndex = index;
    }

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            Time.timeScale = 0;
            this.enabled = false;

            // Wywołaj ShowLCUI w levelCompleted, aby wyświetlić UI Level Complete
            if (levelCompleted != null)
            {
                levelCompleted.ShowLCUI();
            }

            // Odblokuj przycisk "AUTUMN" w menu głównym
            MainMenuManager mainMenuManager = FindObjectOfType<MainMenuManager>();
            if (mainMenuManager != null)
            {
                mainMenuManager.UnlockAutumnButton();
            }
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }

    public static void ResetStatics()
    {
        EnemiesAlive = 0;
    }
}
