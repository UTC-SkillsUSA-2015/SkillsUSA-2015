using UnityEngine;
using System.Collections;
using System;

[RequireComponent (typeof (Rigidbody2D))]
public abstract class Abstract2DPlatformEngine : MonoBehaviour, ISimplePlatformEngine2D {
#if UNITY_EDITOR
    [SerializeField]
    bool DebugMode;
#endif
    public bool Grounded {
        get {
            return kGrounded;
        }
        protected set {
#if UNITY_EDITOR
            if (DebugMode) {
                Debug.Log ("Attempted to set ground state to " + value);
            }
#endif
            if (value != kGrounded) {
                SendMessage ("GroundStateChanged", value, SendMessageOptions.DontRequireReceiver);
                kGrounded = value;
            }
#if UNITY_EDITOR
            if (DebugMode) {
                Debug.Log ("Grounded is " + kGrounded);
            }
#endif
        }
    }

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

    public virtual void Jump (float force) {
        kRigidBody.AddForce (new Vector2 (0, force), ForceMode2D.Impulse);
    }
}
