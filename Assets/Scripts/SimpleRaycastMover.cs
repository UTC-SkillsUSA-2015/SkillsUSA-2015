using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleRaycastMover : Abstract2DPlatformEngine {
    float movement = 0;
    [SerializeField]
    float speedMultiplier = 1;
    /// <summary>
    /// Acceleration used while on the ground. 0 is no acceleration. 1 is instantaneous.
    /// </summary>
    [SerializeField]
    [Range(0,1)]
    float groundAcceleration = 0.75f;
    /// <summary>
    /// Acceleration used while in the air. 0 is no acceleration. 1 is instantaneous.
    /// </summary>
    [SerializeField]
    [Range (0, 1)]
    float airAcceleration = 0.25f;

    public override float WalkMotion {
        set {
            movement = value;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        var velocity = m_Rigidbody.velocity;
        velocity.x = movement * speedMultiplier;
        m_Rigidbody.velocity = velocity;
    }
}
