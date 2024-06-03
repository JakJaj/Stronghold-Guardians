using NUnit.Framework;
using UnityEngine;
using UnityEditor;

public class WaypointsTests
{
    private Waypoints waypoints;
    private GameObject gameObject;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the Waypoints component
        gameObject = new GameObject();
        waypoints = gameObject.AddComponent<Waypoints>();

        // Create child GameObjects
        new GameObject().transform.parent = gameObject.transform;
        new GameObject().transform.parent = gameObject.transform;
    }

    [Test]
    public void InitializePointsTest()
    {
        // Call the InitializePoints method
        waypoints.InitializePoints();

        // Assert that the points array has been initialized correctly
        Assert.AreEqual(2, Waypoints.points.Length);
        Assert.AreEqual(gameObject.transform.GetChild(0), Waypoints.points[0]);
        Assert.AreEqual(gameObject.transform.GetChild(1), Waypoints.points[1]);
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the GameObject after each test
        Object.DestroyImmediate(gameObject);
    }
}