using UnityEngine;

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
    bool kCrouch;

    /// <summary>
    /// Describes whether the character is currently crouching.
    /// Whenever set, alters the respective bool in m_anim.
    /// </summary>
    bool m_Crouch {
        get {
            return kCrouch;
        }
        set {
            this.kCrouch = value;
            m_anim.SetBool (kCrouching, value);
        }
    }

    // Strings used for recieving input/sending output to animator
    #region Input axes/Animator params
    const string kHorizontal = "Horizontal";
    const string kVertical = "Vertical";
    const string kJump = "Jump";
    const string kLight = "LightAttack";
    const string kMedium = "MediumAttack";
    const string kHeavy = "HeavyAttack";
    const string kCrouching = "Crouch";
    const string kGrounded = "Grounded";
    #endregion

    // Use this for initialization
    void Start () {
        m_anim = GetComponent<Animator> ();
        m_engine = GetComponent<ISimplePlatformEngine2D> ();
    }

    // Update is called once per frame
    void Update () {
        #region Movement input
        float h = Input.GetAxisRaw (kHorizontal);
        float v = Input.GetAxisRaw (kVertical);
        m_engine.SetMovement (new Vector2 (h, v));
        if (Input.GetButtonDown (kJump)) {
            m_anim.SetTrigger (kJump);
            m_engine.Jump ();
        }
        m_Crouch= (v == -1);
        #endregion
        #region Attack input
        if (Input.GetButtonDown (kLight)) {
            m_anim.SetTrigger (kLight);
        }
        else if (Input.GetButtonDown (kMedium)) {
            m_anim.SetTrigger (kMedium);
        }
        else if (Input.GetButtonDown (kHeavy)) {
            m_anim.SetTrigger (kHeavy);
        }
        #endregion
    }
}
