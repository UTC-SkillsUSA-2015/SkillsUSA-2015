using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof (Rigidbody2D))]
public abstract class Abstract2DPlatformEngine : MonoBehaviour, ISimplePlatformEngine2D {
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
    protected Rigidbody2D m_Rigidbody {
        get {
            return kRigidBody;
        }
    }

    public abstract float WalkMotion {
        set;
    }

    public virtual Vector2 Motion {
        set {
            WalkMotion = value.x;
        }
    }

    Rigidbody2D kRigidBody;
    bool kGrounded;

    // Use this for initialization
    protected virtual void Start () {
        kRigidBody = GetComponent<Rigidbody2D> ();
    }

    public virtual void Jump () {
        kRigidBody.AddForce (new Vector2 (0, m_JumpForce), ForceMode2D.Impulse);
    }
}
