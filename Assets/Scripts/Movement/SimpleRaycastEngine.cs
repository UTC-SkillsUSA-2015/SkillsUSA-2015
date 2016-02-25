using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleRaycastEngine : Abstract2DPlatformEngine {
    float movement = 0;
    [SerializeField]
    float speedMultiplier = 5;
    /// <summary>
    /// Acceleration used while on the ground.
    /// </summary>
    [SerializeField]
    float groundAcceleration = 0.75f;
    /// <summary>
    /// Acceleration used while in the air.
    /// </summary>
    [SerializeField]
    float airAcceleration = 0.25f;
    [SerializeField]
    float RaycastDist = 0.05f;
    [SerializeField]
    LayerMask ground;
    [SerializeField]
    BoxCollider2D mainHitbox;

    Coroutine currentAccelerationRoutine;

    float Acceleration {
        get {
            var a = (Grounded ? groundAcceleration : airAcceleration);
            if (DebugMode) {
                Debug.Log ("Using accel. " + a);
            }
            return a;
        }
    }

    public override float WalkMotion {
        set {
            if (currentAccelerationRoutine != null) {
                StopCoroutine (currentAccelerationRoutine);
            }
            currentAccelerationRoutine = StartCoroutine (Accelerate (value));
        }
    }
    
    void FixedUpdate () {
        var velocity = m_Rigidbody.velocity;
        velocity.x = movement * speedMultiplier;
        m_Rigidbody.velocity = velocity;
        Grounded = Physics2D.Raycast ((Vector2) transform.position + mainHitbox.offset + Vector2.down * (mainHitbox.size.y / 2),Vector2.down, RaycastDist, ground);
        if (DebugMode) {
            Debug.DrawRay ((Vector2) transform.position + mainHitbox.offset + Vector2.down * (mainHitbox.size.y / 2), Vector2.down * RaycastDist);
            Debug.Log ("FixedUpdate called");
        }
    }

    IEnumerator Accelerate(float newSpeed) {
        while (Mathf.Abs(newSpeed - movement) > Acceleration) {
            movement += Acceleration * Mathf.Sign (newSpeed - movement);
            yield return null;
        }
        movement = newSpeed;
    }
}
