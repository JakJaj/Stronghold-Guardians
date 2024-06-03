using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class TurretTests
{
    private Turret turret;
    private GameObject gameObject;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the Turret component
        gameObject = new GameObject();
        turret = gameObject.AddComponent<Turret>();

        // Set the necessary fields
        turret.range = 15f;
        turret.fireRate = 1f;
        turret.enemyTag = "Enemy";
        turret.partToRotate = new GameObject().transform;
        turret.turnSpeed = 10f;
        turret.bulletPrefab = new GameObject();
        turret.firePoint = new GameObject().transform;
    }

    [Test]
    public void UpdateTargetTest()
    {
        // Create a new GameObject and set its tag to "Enemy"
        GameObject enemy = new GameObject();
        enemy.tag = "Enemy";

        // Call the UpdateTarget method
        turret.UpdateTarget();

        // Assert that the target is the enemy
        Assert.AreEqual(enemy.transform, turret.target);
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameObject after each test
        Object.DestroyImmediate(gameObject);
    }
}