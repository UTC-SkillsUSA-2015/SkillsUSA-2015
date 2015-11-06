using UnityEngine;
using System.Collections;

/// <summary>
/// The Fighter class is the wrapper which commands all other components
/// to make the game object run.
/// </summary>
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (ISimplePlatformEngine2D))]
public class Fighter : MonoBehaviour {
    /// <summary>
    /// Animator component on the fighter. Manages not only physical animations, but hitbox management.
    /// </summary>
    Animator m_anim;
    /// <summary>
    /// Engine on the fighter. Allows them to move.
    /// </summary>
    ISimplePlatformEngine2D m_engine;

    /// <summary>
    /// Describes whether the character is currently crouching.
    /// Should not be modified directly; use m_Crouch property
    /// instead.
    /// </summary>
    bool __crouch;

    /// <summary>
    /// Describes whether the character is currently crouching.
    /// Whenever set, alters the respective bool in m_anim.
    /// </summary>
    bool m_Crouch {
        get {
            return __crouch;
        }

        set {
            this.__crouch = value;
            m_anim.SetBool (k_crouch, value);
        }
    }

    // Strings used for recieving input/sending output to animator
    #region Input axes/Animator params
    const string k_horizontal = "Horizontal";
    const string k_vertical = "Vertical";
    const string k_jump = "Jump";
    const string k_light = "LightAttack";
    const string k_medium = "MediumAttack";
    const string k_heavy = "HeavyAttack";
    const string k_crouch = "Crouch";
    const string k_grounded = "Grounded";
    #endregion

    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator> ();
        m_engine = GetComponent<ISimplePlatformEngine2D> ();
        m_engine.GroundStateChanged.AddListener (Engine_OnGroundStateChanged);
    }

    /// <summary>
    /// Called when the grounded state of
    /// the engine changes, used for setting
    /// the animator state.
    /// </summary>
    /// <param name="state">The state that has just been changed to.</param>
    void Engine_OnGroundStateChanged(bool state) {
        m_anim.SetBool (k_grounded, state);
    }

    // Update is called once per frame
    void Update () {
        #region Movement input
        float h = Input.GetAxisRaw (k_horizontal);
        float v = Input.GetAxisRaw (k_vertical);
        m_engine.SetMovement (new Vector2 (h, v));
        if (Input.GetButtonDown (k_jump)) {
            m_anim.SetTrigger (k_jump);
            m_engine.Jump ();
        }
        m_anim.SetBool (k_crouch, v == -1);
        #endregion

        #region Attack input
        if (Input.GetButtonDown (k_light)) {
            m_anim.SetTrigger (k_light);
        }
        else if (Input.GetButtonDown (k_medium)) {
            m_anim.SetTrigger (k_medium);
        }
        else if (Input.GetButtonDown (k_heavy)) {
            m_anim.SetTrigger (k_heavy);
        }
        #endregion
    }
}
