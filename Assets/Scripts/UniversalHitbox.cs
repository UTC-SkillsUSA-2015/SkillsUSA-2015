using UnityEngine;
using System.Collections;
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

    // Use this for initialization
    void Start () {
        if (!GetComponent<Collider2D> ()) {
            Debug.LogError (NoColliderError);
        }
        if (!m_rigidbody) {
            m_rigidbody = gameObject.transform.root.GetComponent<Rigidbody2D> ();
            if (!m_rigidbody) {
                Debug.LogError (NoRigidbodyError);
            }
        }
    }

    public override void OnTriggerEnter2D (Collider2D collision) {
        throw new NotImplementedException ();
    }

    public override void Launch (Vector2 launchForce) {
        if (m_state != HitboxState.Block) {
            m_rigidbody.velocity = launchForce;
        }
    }

    public override void Damage (float dmg, float chipPercent = 0) {
        if (m_state == HitboxState.Block) {

        }
    }
}
