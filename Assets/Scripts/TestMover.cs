using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SimpleRaycastMover))]
public class TestMover : MonoBehaviour {
    SimpleRaycastMover m_mover;
    // Use this for initialization
    void Start () {
        m_mover = GetComponent<SimpleRaycastMover> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        float h = Input.GetAxisRaw ("Horizontal");
        m_mover.WalkMotion = h;
    }
}
