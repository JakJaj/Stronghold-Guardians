using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 50f;

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos += Vector3.forward * panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos += Vector3.back * panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos += Vector3.right * panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos += Vector3.left * panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }

    public bool GetKey(string key)
    {
        return Input.GetKey(key);
    }

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public float GetMousePositionY()
    {
        return Input.mousePosition.y;
    }

    public float GetMousePositionX()
    {
        return Input.mousePosition.x;
    }

    public int GetScreenHeight()
    {
        return Screen.height;
    }

    public int GetScreenWidth()
    {
        return Screen.width;
    }
    
}
