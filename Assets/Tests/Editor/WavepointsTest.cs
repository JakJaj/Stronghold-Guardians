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
        gameObject = new GameObject();
        waypoints = gameObject.AddComponent<Waypoints>();

        new GameObject().transform.parent = gameObject.transform;
        new GameObject().transform.parent = gameObject.transform;
    }

    [Test]
    public void InitializePointsTest()
    {
        waypoints.InitializePoints();

        Assert.AreEqual(2, Waypoints.points.Length);
        Assert.AreEqual(gameObject.transform.GetChild(0), Waypoints.points[0]);
        Assert.AreEqual(gameObject.transform.GetChild(1), Waypoints.points[1]);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(gameObject);
    }
}
