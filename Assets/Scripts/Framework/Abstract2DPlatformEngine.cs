using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public abstract class Abstract2DPlatformEngine : MonoBehaviour, ISimplePlatformEngine2D {
    public abstract void SetMovement (Vector2 input);

    public bool Grounded {
        get {
            return kGrounded;
        }
        protected set {
            SendMessage ("GroundStateChanged", value, SendMessageOptions.DontRequireReceiver);
            kGrounded = value;
        }
    }

    [SerializeField]
    float m_JumpForce = 100;
    [SerializeField]
    LayerMask m_GroundLayer;

    Rigidbody2D m_RigidBody;
    bool kGrounded;

    // Use this for initialization
    protected virtual void Start () {
        m_RigidBody = GetComponent<Rigidbody2D> ();
    }

    public void Jump () {
        m_RigidBody.AddForce (new Vector2 (0, m_JumpForce), ForceMode2D.Impulse);
    }
}
