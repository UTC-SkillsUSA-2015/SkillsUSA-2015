using UnityEngine;
using System.Collections;

public class TestAnimator : MonoBehaviour {

    string source;

	void Update () {
        source = "Update Function";
        CheckTime(source);
	}

    public void CheckTime(string source)
    {
        Debug.Log("Hello I happened at " + Time.time + " from the " + source);
    }
}
