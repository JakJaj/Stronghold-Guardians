using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class WaveSpawnerTest
{
    private WaveSpawner waveSpawner;
    private GameObject gameObject;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the WaveSpawner component
        gameObject = new GameObject();
        waveSpawner = gameObject.AddComponent<WaveSpawner>();

        // Set the necessary fields
        waveSpawner.enemyPrefab = new GameObject().transform;
        waveSpawner.spawnPoint = new GameObject().transform;
        waveSpawner.timeBetweenWaves = 5f;
    }

    [Test]
    public void GetCountdownTest()
    {
        // Call the GetCountdown method
        float countdown = waveSpawner.GetCountdown();

        // Assert that the countdown is correct
        Assert.AreEqual(2f, countdown);
    }

    [Test]
    public void GetWaveIndexTest()
    {
        // Call the GetWaveIndex method
        int waveIndex = waveSpawner.GetWaveIndex();

        // Assert that the wave index is correct
        Assert.AreEqual(0, waveIndex);
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameObject after each test
        Object.DestroyImmediate(gameObject);
    }
}