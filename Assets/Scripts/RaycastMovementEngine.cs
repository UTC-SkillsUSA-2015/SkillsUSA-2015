using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

// Inherits a required Rigidbody from Abstract2DPlatformEngine
[RequireComponent (typeof (BoxCollider2D))]
public class RaycastMovementEngine : Abstract2DPlatformEngine {
    Vector2 movement;

    protected override void Start () {
        base.Start ();
    }

    public override void SetMovement (Vector2 input) {
        throw new NotImplementedException ();
    }

    protected virtual void FixedUpdate () {
        //var frame_onGround = Physics.Raycast()
    }
}