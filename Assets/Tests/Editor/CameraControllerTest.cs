using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CameraControllerTests
{
    private CameraController _cameraController;

    [SetUp]
    public void SetUp()
    {
        _cameraController = new GameObject().AddComponent<CameraController>();
    }

    [TearDown]
public void TearDown()
{
    if (Application.isEditor)
    {
        Object.DestroyImmediate(_cameraController.gameObject);
    }
    else
    {
        Object.Destroy(_cameraController.gameObject);
    }
}

    [Test]
    public void GetMousePositionY_ReturnsExpectedValue()
    {
        Assert.That(_cameraController.GetMousePositionY(), Is.TypeOf<float>());
    }

    [Test]
    public void GetMousePositionX_ReturnsExpectedValue()
    {
        Assert.That(_cameraController.GetMousePositionX(), Is.TypeOf<float>());
    }

    [Test]
    public void GetScreenHeight_ReturnsExpectedValue()
    {
        Assert.That(_cameraController.GetScreenHeight(), Is.EqualTo(Screen.height));
    }

    [Test]
    public void GetScreenWidth_ReturnsExpectedValue()
    {
        Assert.That(_cameraController.GetScreenWidth(), Is.EqualTo(Screen.width));
    }
}
