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
        gameObject = new GameObject();
        turret = gameObject.AddComponent<Turret>();

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
        GameObject enemy = new GameObject();
        enemy.tag = "Enemy";

        turret.UpdateTarget();

        Assert.AreEqual(enemy.transform, turret.target);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}
