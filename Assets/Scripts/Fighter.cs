using UnityEngine;

/// <summary>
/// The Fighter class is the wrapper which commands all other components
/// to make the game object run.
/// </summary>
public class Fighter : AbstractFighter {
    enum Facing {
        Right, Left
    }

    #region Inspector fields
    [SerializeField]
    FighterInputs m_inputs;
    [SerializeField]
    float fwdSpeed = 5.0f;
    [SerializeField]
    float backSpeed = 5.0f;
    [SerializeField]
    float jumpForce = 100;
    [SerializeField]
    Rigidbody2D m_rigid;
    [SerializeField]
    AudioSource m_voice;
    [SerializeField]
    [Tooltip("Optional")]
    AudioSource m_contact;
    [SerializeField]
    FighterSoundset m_sounds;
    [SerializeField]
    HitManager m_hitManager;
    [SerializeField]
    Abstract2DPlatformEngine m_engine;
    [SerializeField]
    Animator m_anim;
    [SerializeField]
    int m_team;
    [SerializeField]
    uint m_maxHealth;
    [SerializeField]
    HealthBar m_healthbar;
    [SerializeField]
    bool debug;
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

    bool Stunned {
        get {
            return stunTimer > 0;
        }
    }
    int stunTimer;
    int m_health;

    bool hitFlag;
    bool jumpFlag;
    SoundGroup contactSounds;

    float movementInput;
    float verticalInput;

    [SerializeField]
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
        m_health = (int) m_maxHealth;
    }


    protected override void UpdateFacing() {
        var rot = gameObject.transform.rotation;
        if (face == Facing.Right) {
            rot.y = 0;
        }
        else {
            rot.y = 180;
        }
        gameObject.transform.rotation = rot;
    }

    protected override void UpdateAttacks() {
        while (m_hitManager.HasAttack) {
            var atk = m_hitManager.PullAttack;
            stunTimer = (int) atk.kData.Hitstun + 1;
            Vector2 scaler = Vector2.up + (face == Facing.Right ? Vector2.right : Vector2.left);
            m_rigid.velocity = Vector2.Scale (atk.TotalLaunch, scaler);
            if (atk.TotalDamage > 0) {
                hitFlag = true;
                m_health -= atk.TotalDamage;
            }
            contactSounds = atk.kData.ContactSounds;
            m_healthbar.SetHealth ((float) m_health / m_maxHealth);
        }
    }

    protected override void UpdateMovement () {
        if (!Stunned) {
            movementInput = m_inputs.HorizontalInput;
            verticalInput = m_inputs.VerticalInput;
            m_engine.WalkMotion = movementInput * MoveMultiplier (movementInput);
            jumpFlag = (m_inputs.VerticalInput > 0) && m_engine.Grounded;
            if (m_engine.Grounded && jumpFlag) {
                m_engine.Jump (jumpForce);
            }
        }
    }

    protected override void UpdateAnimator () {
        m_anim.SetBool ("Stunned", Stunned);
        m_anim.SetBool ("Grounded", m_engine.Grounded);
        m_anim.SetBool ("MovingForward", MovingForward (movementInput));
        m_anim.SetBool ("MovingBackward", MovingBackward (movementInput));
        m_anim.SetBool ("Crouch", verticalInput < 0);
        m_anim.SetBool ("Jump", verticalInput > 0);
        if (m_inputs.LightInput)
            m_anim.SetTrigger ("Light");
        else if (m_inputs.MediumInput)
            m_anim.SetTrigger ("Medium");
        else if (m_inputs.HeavyInput)
            m_anim.SetTrigger ("Heavy");
    }

    protected override void UpdateAudio () {
        if (hitFlag && contactSounds && m_contact) {
            m_contact.clip = contactSounds.RandomClip;
            m_contact.pitch = Random.Range (0.95f, 1.2f);
            m_contact.Play();
        }

        if (hitFlag) {
            m_voice.clip = m_sounds.randomHit;
        }
        else if (jumpFlag) {
            m_voice.clip = m_sounds.randomJump;
        }
        if (jumpFlag || hitFlag) {
            m_voice.pitch = Random.Range (0.95f, 1.2f);
            m_voice.Play ();
        }
        hitFlag = false;
        jumpFlag = false;
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
}
