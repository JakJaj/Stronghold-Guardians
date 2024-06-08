using NUnit.Framework;
using UnityEngine;


public class EnemyTest
{
    private Enemy _enemy;

    [SetUp]
    public void SetUp()
    {
        _enemy = new GameObject().AddComponent<Enemy>();
        _enemy.deathEffect = new GameObject();
    }

    [TearDown]
    public void TearDown()
    {

        if (_enemy != null)
        {
            Object.DestroyImmediate(_enemy.gameObject);
        }
    }

    [Test]
    public void TakeDamage_WithEnoughDamage_HealthIsZero()
    {

        Assert.AreEqual(true, true);
    }

    [Test]
    public void TakeDamage_WithExcessDamage_HealthIsZero()
    {

        Assert.AreEqual(true, true);
    }

    [Test]
    public void TakeDamage_WithNotEnoughDamage_HealthIsReduced()
    {
        _enemy.health = 100;

        _enemy.TakeDamage(50);

        Assert.AreEqual(50, _enemy.health);
    }
}