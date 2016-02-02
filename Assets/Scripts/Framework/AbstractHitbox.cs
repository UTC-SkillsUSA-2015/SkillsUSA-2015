using UnityEngine;
using System.Collections;

public abstract class AbstractHitbox : MonoBehaviour {
    [SerializeField]
    Collider2D hitbox;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    /// <summary>
    /// Override this so the derived classes know how to behave when contacted.
    /// </summary>
    /// <param name="collision">The collider on the hitbox being contacted.</param>
    public abstract void OnTriggerEnter2D (Collider2D collision);
    /// <summary>
    /// Called for attacks that launch the opponent. Blocking or evading may nullify this.
    /// </summary>
    /// <param name="launchForce">The direction and magnitude of the launch.</param>
    public abstract void Launch (Vector2 launchForce);
    /// <summary>
    /// Damages the opponent, but still does a small percent of damage if
    /// blocked.
    /// </summary>
    /// <param name="dmg">The amount of damage to deal.</param>
    /// <param name="chipPercent">The percent of damage dealt if blocked.</param>
    public abstract void Damage (float dmg, float chipPercent = 0);
}
