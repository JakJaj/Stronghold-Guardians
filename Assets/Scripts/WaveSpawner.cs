using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;
    private List<GameObject> enemies = new List<GameObject>();

    private Label waveCountdownLabel;

    void Start()
    {
        var uiDocument = FindObjectOfType<UIDocument>();
        var root = uiDocument.rootVisualElement;

        waveCountdownLabel = root.Q<Label>("WaveCountdownText");
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        if (waveCountdownLabel != null)
        {
            waveCountdownLabel.text = countdown.ToString("F2");
        }
        else
        {
            Debug.LogError("WaveCountdownText label not found");
        }
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
