using UnityEngine;
using System.Collections.Generic;
using System;

public class UniversalHitbox : AbstractHitbox {
    public enum HitboxState {
        Normal,
        Block,
        Attack
    }

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
    #endregion

    [SerializeField]
    HitboxState m_state;
    /// <summary>
    /// Optional field. If not specified, will attempt to pull from the root GameObject
    /// </summary>
    [SerializeField]
    Rigidbody2D m_rigidbody;

    AttackData m_attack;
    List<AbstractHitbox> m_intersecting = new List<AbstractHitbox> ();
    int m_frameTimer = 0;

    // Use this for initialization
    void Start () {
#if UNITY_EDITOR
        if (!GetComponent<Collider2D> ()) {
            Debug.LogError (NoColliderError);
        }
#endif
        if (!m_rigidbody) {
            m_rigidbody = gameObject.transform.root.GetComponent<Rigidbody2D> ();
#if UNITY_EDITOR
            if (!m_rigidbody) {
                Debug.LogError (NoRigidbodyError);
            }
#endif
        }
    }

    public void Update () {
        if (m_attack) {
            var atk = new Attack { data = m_attack, team = 0, id = GenerateID(m_attack) };
        }
    }

    private int GenerateID (AttackData data) {
        return data.priority;
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
    public void Attack (AttackData attack, int numberOfFrames) {
        m_attack = attack;
        m_frameTimer = numberOfFrames;
    }

    /// <summary>
    /// Cancels the currently queued attack
    /// </summary>
    void CancelAttack () {
        m_attack = null;
    }

    /// <summary>
    /// Adds a hitbox to the internal hitbox list
    /// </summary>
    /// <param name="collision">The collider that entered</param>
    public override void OnTriggerEnter2D (Collider2D collision) {
        var otherHitbox = collision.GetComponent<AbstractHitbox> ();
        if (otherHitbox && otherHitbox.transform.root != transform.root) {
            m_intersecting.Add (otherHitbox);
        }
    }

    /// <summary>
    /// Removes a hitbox from the internal hitbox list
    /// </summary>
    /// <param name="collision">The collider that left</param>
    public void OnTriggerExit2D (Collider2D collision) {
        m_intersecting.Remove (collision.GetComponent<AbstractHitbox> ());
    }

    /// <summary>
    /// Called by other hitboxes when an attack connects.
    /// This is called BY the affecting, ON the affected.
    /// </summary>
    /// <param name="attack">The attack this hitbox is being hit with.</param>
    public override void Hit (Attack attack) {
        throw new NotImplementedException ();
    }
}
