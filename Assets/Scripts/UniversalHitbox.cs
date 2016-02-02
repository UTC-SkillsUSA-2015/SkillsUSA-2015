using UnityEngine;
using System.Collections;
using System;

public class UniversalHitbox : AbstractHitbox {
    public enum HitboxState {
        Normal,
        Block,
        Attack,
        Dodge
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public override void OnTriggerEnter2D (Collider2D collision) {
        throw new NotImplementedException ();
    }

    public override void Launch (Vector2 launchForce) {
        throw new NotImplementedException ();
    }

    public override void Damage (float dmg) {
        throw new NotImplementedException ();
    }

    public override void Damage (float dmg, float chipPercent) {
        throw new NotImplementedException ();
    }
}
