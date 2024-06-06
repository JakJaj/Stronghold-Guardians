using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BuildManagerTests
{
    private GameObject buildManagerObject;
    private BuildManager buildManager;

    [SetUp]
    public void SetUp()
    {
        buildManagerObject = new GameObject();
        buildManager = buildManagerObject.AddComponent<BuildManager>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(buildManagerObject);
    }

    [Test]
    public void BuildTurretOn_NoTurretSelected_LogsError()
    {
        var nodeObject = new GameObject();
        var node = nodeObject.AddComponent<Node>();

        LogAssert.Expect(LogType.Error, "No turret selected to build!");
        buildManager.BuildTurretOn(node);
    }
}