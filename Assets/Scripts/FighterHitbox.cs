using UnityEngine;
using System.Collections.Generic;
using System;

public class FighterHitbox : AbstractAttackingHitbox {
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

    protected override int Team {
        get {
            return m_parent.Team;
        }
    }

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
        if (!GetComponent<Collider2D> ()) {
            Debug.LogError (NoColliderError);
        }
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
    public override void Attack (AttackData attack) {
        m_attack = attack;
        m_frameTimer = (int) attack.NumberOfFrames;
        state = State.Attack;
    }

    /// <summary>
    /// Cancels the currently queued attack
    /// </summary>
    void CancelAttack () {
        m_attack = null;
        state = State.Normal;
    }

    /// <summary>
    /// Adds a hitbox to the internal hitbox list
    /// </summary>
    /// <param name="collision">The collider that entered</param>
    public void OnTriggerEnter2D (Collider2D collision) {
        if (debug) {
            Debug.Log (collision.name + " intersected " + gameObject.name);
        }
        var otherHitbox = collision.GetComponent<AbstractHitbox> ();
        if (otherHitbox /* ... is not null */ && otherHitbox.transform.root != transform.root) {
            m_intersecting.Add (otherHitbox);
            if (debug) {
                Debug.Log (collision.name + " added to " + gameObject.name + "'s intersecting hitboxes");
            }
        }
    }

    /// <summary>
    /// Removes a hitbox from the internal hitbox list
    /// </summary>
    /// <param name="collision">The collider that left</param>
    public void OnTriggerExit2D (Collider2D collision) {
        if (debug) {
            Debug.Log (collision.name + " removed from " + gameObject.name + "'s intersecting hitboxes");
        }
        m_intersecting.Remove (collision.GetComponent<AbstractHitbox> ());
    }

    /// <summary>
    /// Called by other hitboxes when an attack connects.
    /// This is called BY the affecting, ON the affected.
    /// </summary>
    /// <param name="attack">The attack this hitbox is being hit with.</param>
    public override void Hit (Attack attack) {
        if (debug) {
            Debug.Log (gameObject.name + " has been hit by " + attack.kData.name);
        }
        switch (state) {
            case State.Normal:
                m_hitManager.AddAttack (attack);
                break;
            case State.Block:
                attack.damageMultiplier *= attack.kData.Chip;
                attack.launchScale.x = blockingLaunchScale;
                attack.launchScale.y = (m_parent.Grounded ? 0 : blockingLaunchScale);
                attack.wasBlocked = true;
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
    /// Utility method to generate attack IDs.
    /// </summary>
    /// <param name="data">The data to create an id for.</param>
    /// <returns>An entirely unique id for the data.</returns>
    protected override int GenerateID (AttackData data) {
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
