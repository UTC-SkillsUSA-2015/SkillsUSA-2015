using UnityEngine;
using System.Collections;

public class FollowSelector : MonoBehaviour {

    [SerializeField]
    GameObject[] selectors;

	void Update () {
	    foreach(GameObject obj in selectors)
        {
            if(obj.activeInHierarchy == true)
            {
                transform.position = obj.transform.position;
            }
        }
	}
}
