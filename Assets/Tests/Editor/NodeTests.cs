using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class NodeTests
{
    private Node node;
    private GameObject gameObject;

    [SetUp]
    public void Setup()
    {
        gameObject = new GameObject();
        node = gameObject.AddComponent<Node>();

        node.positionOffset = new Vector3(1, 1, 1);
    }

    [Test]
    public void GetBuildPositionTest()
    {
        Vector3 buildPosition = node.GetBuildPosition();

        Assert.AreEqual(gameObject.transform.position + node.positionOffset, buildPosition);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}
