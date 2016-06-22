using UnityEngine;
using System.Collections;

public class cameraFollowingScript : MonoBehaviour {

    [SerializeField]
    Transform player1;

    [SerializeField]
    Transform player2;

    [SerializeField]
    float minSizeY = 1;

    [SerializeField]
    float bufferX = 1;

    [SerializeField]
    float bufferY = 1;

    [SerializeField]
    Camera cam;

    float cameraSizeFloat;

    void Update()
    {
        SetCameraPos();
        SetCameraSize();
    }

    void SetCameraPos()
    {
        Vector3 middle = (player1.position + player2.position) * 0.5f;
        GetComponent<Camera>().transform.position = new Vector3(
            middle.x,
            middle.y,
            GetComponent<Camera>().transform.position.z
        );
    }

    void SetCameraSize()
    {
        //horizontal size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;
        //multiplying by 0.5, because the ortographicSize is actually half the height
        float width = Mathf.Abs((player1.position.x - player2.position.x) * 0.5f) + bufferX;
        float height = Mathf.Abs((player1.position.y - player2.position.y) * 0.5f) + bufferY;
        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX);
        cam.orthographicSize = Mathf.Max(height,camSizeX * Screen.height / Screen.width, minSizeY);
        //GetComponent<Camera>().orthographicSize = Mathf.Clamp(Mathf.Max(height, camSizeX * Screen.height / Screen.width, minSizeY), minSizeY, maxSizeY);

    }
}
