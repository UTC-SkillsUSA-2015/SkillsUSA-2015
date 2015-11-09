using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;

[RequireComponent (typeof (BoxCollider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class RaycastMovementEngine : Abstract2DPlatformEngine {
    [SerializeField]
    LayerMask m_GroundLayer;
    Vector2 movement;

    public override void SetMovement (Vector2 input) {
        throw new NotImplementedException ();
    }
}