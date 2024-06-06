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
        gameObject = new GameObject();
        waveSpawner = gameObject.AddComponent<WaveSpawner>();

        waveSpawner.enemyPrefab = new GameObject().transform;
        waveSpawner.spawnPoint = new GameObject().transform;
        waveSpawner.timeBetweenWaves = 5f;
    }

    [Test]
    public void GetCountdownTest()
    {
        float countdown = waveSpawner.GetCountdown();

        Assert.AreEqual(2f, countdown);
    }

    [Test]
    public void GetWaveIndexTest()
    {
        int waveIndex = waveSpawner.GetWaveIndex();

        Assert.AreEqual(0, waveIndex);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}
