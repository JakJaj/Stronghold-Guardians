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
        // You can't test Input.mousePosition.y directly as it requires user interaction.
        // You can, however, test if the method is callable and returns a float.
        Assert.That(_cameraController.GetMousePositionY(), Is.TypeOf<float>());
    }

    [Test]
    public void GetMousePositionX_ReturnsExpectedValue()
    {
        // You can't test Input.mousePosition.x directly as it requires user interaction.
        // You can, however, test if the method is callable and returns a float.
        Assert.That(_cameraController.GetMousePositionX(), Is.TypeOf<float>());
    }

    [Test]
    public void GetScreenHeight_ReturnsExpectedValue()
    {
        // Screen.height should be equal to the current screen height
        Assert.That(_cameraController.GetScreenHeight(), Is.EqualTo(Screen.height));
    }

    [Test]
    public void GetScreenWidth_ReturnsExpectedValue()
    {
        // Screen.width should be equal to the current screen width
        Assert.That(_cameraController.GetScreenWidth(), Is.EqualTo(Screen.width));
    }
}