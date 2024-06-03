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
        // Create a new GameObject and add the Node component
        gameObject = new GameObject();
        node = gameObject.AddComponent<Node>();

        // Set the positionOffset
        node.positionOffset = new Vector3(1, 1, 1);
    }

    [Test]
    public void GetBuildPositionTest()
    {
        // Call the GetBuildPosition method
        Vector3 buildPosition = node.GetBuildPosition();

        // Assert that the build position is correct
        Assert.AreEqual(gameObject.transform.position + node.positionOffset, buildPosition);
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameObject after each test
        Object.DestroyImmediate(gameObject);
    }
}