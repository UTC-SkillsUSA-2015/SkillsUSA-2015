using UnityEngine;
using System.Collections;
using System;

public class LazyMovementEngine : Abstract2DPlatformEngine {
    public override float WalkMotion {
        set {
            if (Grounded && !ignoreInputs)
                m_Rigidbody.velocity = new Vector2 (value, m_Rigidbody.velocity.y);
        }
    }

    [SerializeField]
    BoxCollider2D mainHitbox;
    [SerializeField]
    float RaycastDist;
    [SerializeField]
    LayerMask ground;

    float horizontal;
    bool refresh;

    public bool ignoreInputs = false;

    public void FixedUpdate () {
        if (refresh) {
            m_Rigidbody.velocity = new Vector2 (horizontal, m_Rigidbody.velocity.y);
            refresh = false;
        }
        Grounded = Physics2D.Raycast (
            (Vector2) transform.position + mainHitbox.offset + Vector2.down * (mainHitbox.size.y / 2),
            Vector2.down,
            RaycastDist,
            ground
            );
    }
}
