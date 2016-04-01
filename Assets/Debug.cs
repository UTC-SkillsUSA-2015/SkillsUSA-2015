using UnityEngine;
using System.Collections;

public class Debug : MonoBehaviour {

	void Update()
    {
        if (Input.GetButton("AP1"))
        {
            UnityEngine.Debug.Log("Hello from a");
        }
    }
}
