using UnityEngine;
using System.Collections.Generic;
using System;

public class FighterHitbox : AbstractHitbox {
    #region Error messages
    string NoColliderError {
        get {
            return gameObject.name + " has no Collider2D; Hitbox script is redundant";
        }
    }
    string NoRigidbodyError {
        get {
            return gameObject.name + " RigidBody2D not specified, and no Rigidbody2D is on the root GameObject";
        }
    }
    string InvalidStateSelectionError {
        get {
            return "Invalid HitboxState passed; continuing to process attack as normal";
        }
    }
    #endregion

    /// <summary>
    /// Optional field. If not specified, will attempt to pull from the root GameObject
    /// </summary>
    //[SerializeField]
    //Rigidbody2D m_rigidbody;
    //[SerializeField]
    //FighterHealth m_health;
    [SerializeField]
    Fighter m_parent;
    [SerializeField]
    HitManager m_hitManager;
    [SerializeField]
    AttackData m_conflcitResolution;
    [SerializeField]
    bool debug;

    AttackData m_attack;
    List<AbstractHitbox> m_intersecting = new List<AbstractHitbox> ();
    int m_frameTimer = 0;
    float blockingLaunchScale = 0.5f;

    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        if (!GetComponent<Collider2D> ()) {
            Debug.LogError (NoColliderError);
        }
#endif
//        if (!m_rigidbody) {
//            m_rigidbody = gameObject.transform.root.GetComponent<Rigidbody2D> ();
//#if UNITY_EDITOR
//            if (!m_rigidbody) {
//                Debug.LogError (NoRigidbodyError);
//            }
//#endif
//        }
    }

    public void Update () {
        if (m_attack && m_intersecting.Count > 0) {
            var atk = GenerateAttack(m_attack);
            foreach (var c in m_intersecting) {
                c.Hit (atk);
            }
        }
    }

    /// <summary>
    /// Decrements the frame counter once all other actions are complete.
    /// </summary>
    public void LateUpdate () {
        if (m_frameTimer > 0) {
            m_frameTimer--;
            if (m_frameTimer <= 0) {
                CancelAttack ();
            }
        }
    }

    /// <summary>
    /// Called by the Animator when an attack's hit frames begin.
    /// </summary>
    /// <param name="attack">The data of the attack.</param>
    public void Attack (AttackData attack) {
        m_attack = attack;
        m_frameTimer = (int) attack.NumberOfFrames;
        m_state = State.Attack;
    }

    /// <summary>
    /// Cancels the currently queued attack
    /// </summary>
    void CancelAttack () {
        m_attack = null;
        m_state = State.Normal;
    }

    /// <summary>
    /// Adds a hitbox to the internal hitbox list
    /// </summary>
    /// <param name="collision">The collider that entered</param>
    public override void OnTriggerEnter2D (Collider2D collision) {
#if UNITY_EDITOR
        if (debug) {
            Debug.Log (collision.name + " intersected " + gameObject.name);
        }
#endif
        var otherHitbox = collision.GetComponent<AbstractHitbox> ();
        if (otherHitbox /* ... is not null */ && otherHitbox.transform.root != transform.root) {
            m_intersecting.Add (otherHitbox);
#if UNITY_EDITOR
            if (debug) {
                Debug.Log (collision.name + " added to " + gameObject.name + "'s intersecting hitboxes");
            }
#endif
        }
    }

    /// <summary>
    /// Removes a hitbox from the internal hitbox list
    /// </summary>
    /// <param name="collision">The collider that left</param>
    public void OnTriggerExit2D (Collider2D collision) {
#if UNITY_EDITOR
        if (debug) {
            Debug.Log (collision.name + " removed from " + gameObject.name + "'s intersecting hitboxes");
        }
#endif
        m_intersecting.Remove (collision.GetComponent<AbstractHitbox> ());
    }

    /// <summary>
    /// Called by other hitboxes when an attack connects.
    /// This is called BY the affecting, ON the affected.
    /// </summary>
    /// <param name="attack">The attack this hitbox is being hit with.</param>
    public override void Hit (Attack attack) {
#if UNITY_EDITOR
        if (debug) {
            Debug.Log (gameObject.name + " has been hit by " + attack.kData.name);
        }
#endif
        switch (m_state) {
            case State.Normal:
#if UNITY_EDITOR
                if (debug) {
                    Debug.Log ("Adding attack to hitmanager", gameObject);
                }
#endif
                m_hitManager.AddAttack (attack);
                break;
            case State.Block:
#if UNITY_EDITOR
                if (debug) {
                    Debug.Log ("Blocked");
                }
#endif
                attack.damageMultiplier *= attack.kData.Chip;
                attack.launchScale.x = blockingLaunchScale;
                attack.launchScale.y = (m_parent.Grounded ? 0 : blockingLaunchScale);
                goto case State.Normal;
            case State.Attack:
                if (attack.kData.Priority > m_attack.Priority) goto case State.Normal;
                else if (attack.kData.Priority == m_attack.Priority)
                    m_hitManager.AddAttack (GenerateAttack(m_conflcitResolution));
                break;
            default:
                Debug.LogError (InvalidStateSelectionError);
                goto case State.Normal;
        }
    }

    /// <summary>
    /// Utility method to quickly create an attack from some data.
    /// </summary>
    /// <param name="data">The AttackData to create an attack for.</param>
    /// <returns>An Attack using the given data.</returns>
    private Attack GenerateAttack (AttackData data, float damageMult = 1.00f,
        float xKnockbackMult = 1.00f, float yKnockbackMult = 1.00f) {
        return new Attack (data, m_parent.Team, GenerateID (data),
            damageMult, xKnockbackMult, yKnockbackMult);
    }

    /// <summary>
    /// Utility method to generate attack IDs.
    /// </summary>
    /// <param name="data">The data to create an id for.</param>
    /// <returns>An entirely unique id for the data.</returns>
    private int GenerateID (AttackData data) {
        var id = data.GetHashCode () * 23;
        id <<= data.Priority;
        id += 29 * m_parent.Team;
        id *= (int) m_parent.CurrentHealth;
        id <<= 5;
        id *= Time.frameCount;
#if UNITY_EDITOR
        if (debug) {
            Debug.Log ("Id: " + id);
        }
#endif
        return id;
        // return (((data.GetHashCode() * 23) << data.Priority) + 29 * parent.Team) * (int) m_health.CurrentHealth;
    }
}
