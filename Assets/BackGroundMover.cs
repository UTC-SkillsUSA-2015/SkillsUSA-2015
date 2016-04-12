using UnityEngine;
using System.Collections;

public class BackGroundMover : MonoBehaviour {

    [SerializeField]
    GameObject selectorFollow;

    [SerializeField]
    float Speed;

    [SerializeField]
    float moveAmount;

    void Start()
    {
        //transform.localPosition = new Vector3(0, (transform.localPosition.y - selectorFollow.transform.localPosition.y) * moveAmount, 0);
    }

    void FixedUpdate()
    {
        transform.localPosition = new Vector3(0,Mathf.Lerp(transform.localPosition.y,(transform.localPosition.y - selectorFollow.transform.localPosition.y)*moveAmount,Time.time * Speed), 0);
    }
}
