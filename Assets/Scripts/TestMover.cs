using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SimpleRaycastMover))]
public class TestMover : MonoBehaviour {
    [SerializeField]
    float JumpForce = 100;

    SimpleRaycastMover m_mover;
    // Use this for initialization
    void Start () {
        m_mover = GetComponent<SimpleRaycastMover> ();
    }

    // Update is called once per frame
    void FixedUpdate () {
        float h = Input.GetAxisRaw ("Horizontal");
        m_mover.WalkMotion = h;
        if (Input.GetAxisRaw("Vertical") > 0 && m_mover.Grounded) {
            Debug.Log ("Jumping");
            m_mover.Jump (JumpForce);
        }
    }
}
