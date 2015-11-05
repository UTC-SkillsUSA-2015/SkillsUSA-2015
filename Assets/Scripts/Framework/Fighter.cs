using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (IPlatformEngine2D))]
public class Fighter : MonoBehaviour {
    /// <summary>
    /// Animator component on the fighter. Manages not only physical animations, but hitbox management.
    /// </summary>
    Animator m_anim;
    /// <summary>
    /// Engine on the fighter. Allows them to move.
    /// </summary>
    IPlatformEngine2D m_engine;

    #region Input axes
    const string k_horizontal = "Horizontal";
    const string k_vertical = "Vertical";
    const string k_jump = "Jump";
    #endregion

    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator> ();
        m_engine = GetComponent<IPlatformEngine2D> ();
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxisRaw (k_horizontal);
        float v = Input.GetAxisRaw (k_vertical);
        m_engine.SetMovement (new Vector2 (h, v));
        if (Input.GetButtonDown (k_jump)) {
            m_anim.SetTrigger ("Jump");
            m_engine.Jump ();
        }
        // Add stuff about animation stuff
    }
}
