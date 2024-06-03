using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BulletTests
{
    private GameObject bulletObject;
    private Bullet bullet;

    [SetUp]
    public void SetUp()
    {
        bulletObject = new GameObject();
        bullet = bulletObject.AddComponent<Bullet>();
    }

    [TearDown]
public void TearDown()
{
    if (Application.isEditor)
    {
        Object.DestroyImmediate(bulletObject);
    }
    else
    {
        Object.Destroy(bulletObject);
    }
}

    [Test]
public void Seek_SetsTargetCorrectly()
{
    var targetObject = new GameObject();
    var targetTransform = targetObject.transform;

    bullet.Seek(targetTransform);

    Assert.AreEqual(targetTransform, bullet.GetCurrentTarget());
}
}