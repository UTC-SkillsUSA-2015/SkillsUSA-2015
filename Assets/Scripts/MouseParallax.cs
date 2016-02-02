using UnityEngine;
using System.Collections;

public class MouseParallax : MonoBehaviour {

    [SerializeField]
    float cameraMoveSpeed;

    [SerializeField]
    float limitFactor;

    [SerializeField]
    bool isUI;

    void Update()
    {
        if(!isUI)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraMoveSpeed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraMoveSpeed, 0);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limitFactor, limitFactor), (Mathf.Clamp(transform.position.y, -limitFactor, limitFactor)), 0);

        }

        else
        {
            transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * cameraMoveSpeed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * cameraMoveSpeed, 0);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -limitFactor, limitFactor), (Mathf.Clamp(transform.position.y, -limitFactor, limitFactor)), 0);
        }
    }
}
