using UnityEngine;
using System.Collections;

public abstract class AbstractHitbox : MonoBehaviour {
    public enum State {
        Normal,
        Block,
        Attack
    }
    public State state;
    [SerializeField]
    Collider2D hitbox;
    /// <summary>
    /// Override this so the derived classes know how to behave when contacted.
    /// </summary>
    /// <param name="collision">The collider on the hitbox being contacted.</param>
    public abstract void OnTriggerEnter2D (Collider2D collision);
    /// <summary>
    /// Called when an attack lands.
    /// </summary>
    /// <param name="attack">Data of the attack.</param>
    public abstract void Hit (Attack attack);
}
