using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pulse : MonoBehaviour {

    [SerializeField]
    float bounceSpeed = 0.5f;

    [SerializeField]
    float scaleFactor = 0.1f;

    [SerializeField]
    Vector2 startScale;

    Vector2 bounceScale;

   
	void Update () {
        bounceScale = new Vector2(startScale.x + scaleFactor, startScale.y + scaleFactor);
        transform.localScale = Vector3.Lerp(startScale, bounceScale, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / bounceSpeed, 1f)));
    }
}
