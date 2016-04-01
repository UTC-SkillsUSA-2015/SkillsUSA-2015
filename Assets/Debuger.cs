using UnityEngine;
using System.Collections;

public class Debuger : MonoBehaviour {

	void Update()
    {
        string[] names = Input.GetJoystickNames();
        Debug.Log(names[0]);
        Debug.Log(names[1]);

        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            Debug.Log("Hello from a");
        }
    }
}
