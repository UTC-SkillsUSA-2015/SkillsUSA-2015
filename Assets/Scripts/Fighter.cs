using UnityEngine;

/// <summary>
/// The Fighter class is the wrapper which commands all other components
/// to make the game object run.
/// </summary>
public class Fighter : MonoBehaviour {
    enum Facing {
        Right, Left
    }

    #region Inspector fields
    [SerializeField]
    float fwdSpeed = 5.0f;
    [SerializeField]
    float backSpeed = 5.0f;
    [SerializeField]
    float jumpForce = 100;
    [SerializeField]
    Rigidbody2D m_rigid;
    [SerializeField]
    HitManager m_hitManager;
    //[SerializeField]
    //FighterHealth m_health;
    [SerializeField]
    Abstract2DPlatformEngine m_engine;
    [SerializeField]
    Animator m_anim;
    [SerializeField]
    int m_team;
    [SerializeField]
    uint m_maxHealth;
    #endregion

    public int Team {
        get {
            return m_team;
        }
    }
    public bool Grounded {
        get {
            return m_engine.Grounded;
        }
    }
    public Vector2 LaunchScaleVector {
        get {
            return (Vector2) gameObject.transform.right + Vector2.up;
        }
    }
    public int CurrentHealth {
        get {
            return m_health;
        }
    }

    Facing face {
        get {
            return (opponent.transform.position.x > gameObject.transform.position.x ?
                Facing.Right :
                Facing.Left);
        }
    }

    bool stunned;
    int stunTimer;
    int m_health;

    [HideInInspector]
    public GameObject opponent;

    #region Error messages
    string NoMovementEngineError {
        get {
            return "Could not find movement engine for Fighter script on " + gameObject.name;
        }
    }
    string NoAnimatorError {
        get {
            return "Could not find animator for Fighter script on " + gameObject.name;
        }
    }
    #endregion

    // Start is called just before any of the Update methods is called the first time
    public void Start () {
        if (!m_engine) {
            m_engine = GetComponent<Abstract2DPlatformEngine> ();
#if UNITY_EDITOR
            if (!m_engine)
                Debug.LogError (NoMovementEngineError);
#endif
        }
        if (!m_anim) {
            m_anim = GetComponent<Animator> ();
#if UNITY_EDITOR
            if (!m_anim)
                Debug.LogError (NoAnimatorError);
#endif
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update () {
        #region Movement
        float h = Input.GetAxisRaw ("Horizontal");
        m_engine.WalkMotion = h * MoveMultiplier (h);
        bool jump = Input.GetAxisRaw ("Vertical") == 1;
        if (m_engine.Grounded && jump) {
            m_engine.Jump (jumpForce);
        }
        #endregion

        #region Attacks
        while (m_hitManager.HasAttack) {
            var atk = m_hitManager.PullAttack;
            stunned = true;
            stunTimer = (int) atk.kData.Hitstun + 1;
            m_rigid.velocity = atk.TotalLaunch;
            m_health -= atk.TotalDamage;
        }
        #endregion

        #region Animator
        m_anim.SetBool ("Stunned", true);
        m_anim.SetBool ("Grounded", m_engine.Grounded);
        m_anim.SetBool ("MovingForward", MovingForward (h));
        m_anim.SetBool ("MovingBackward", MovingBackward (h));
        if (Input.GetButtonDown ("Light Attack"))
            m_anim.SetTrigger ("Light");
        else if (Input.GetButtonDown ("Medium Attack"))
            m_anim.SetTrigger ("Medium");
        else if (Input.GetButtonDown ("Heavy Attack"))
            m_anim.SetTrigger ("Heavy");
        #endregion
    }

    public void LateUpdate () {
        if (stunTimer > 0) {
            stunTimer--;
        }
    }

    float MoveMultiplier (float direction) {
        if (MovingForward (direction)) {
            return fwdSpeed;
        }
        else if (MovingBackward (direction)) {
            return backSpeed;
        }
        else {
            return 0;
        }
    }

    bool MovingForward (float movement) {
        return (movement > 0 && face == Facing.Right) || (movement < 0 && face == Facing.Left);
    }

    bool MovingBackward (float movement) {
        return (movement > 0 && face == Facing.Left) || (movement < 0 && face == Facing.Right);
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    public void FixedUpdate () {

    }
}
