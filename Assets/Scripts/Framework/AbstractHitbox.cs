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
    abstract protected int Team {
        get;
    }
    /// <summary>
    /// Called when an attack lands.
    /// </summary>
    /// <param name="attack">Data of the attack.</param>
    public abstract void Hit (Attack attack);
}
