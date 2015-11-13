using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

// Inherits a required Rigidbody from Abstract2DPlatformEngine
public class RaycastMovementEngine : Abstract2DPlatformEngine {
    Vector2 movement;
    [SerializeField]
    Vector2 leftCorner = new Vector2 ();
    [SerializeField]
    Vector2 rightCorner = new Vector2 ();

    protected override void Start () {
        base.Start ();
    }

    public override void SetMovement (Vector2 input) {
        
    }

    protected virtual void FixedUpdate () {
        Ray grounderRayL = new Ray (leftCorner, Vector3.down);
        Ray grounderRayR = new Ray (rightCorner, Vector3.down);
    }

    public override void Jump() {
        m_Rigidbody.constraints = m_Rigidbody.constraints ^ RigidbodyConstraints2D.FreezePositionY;
        base.Jump ();
    }
}