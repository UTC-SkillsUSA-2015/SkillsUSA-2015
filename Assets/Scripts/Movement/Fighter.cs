using UnityEngine;

/// <summary>
/// The Fighter class is the wrapper which commands all other components
/// to make the game object run.
/// </summary>
public class Fighter : MonoBehaviour {
    [SerializeField]
    Abstract2DPlatformEngine m_engine;
    [SerializeField]
    Animator m_anim;

    [SerializeField]
    private int m_team;

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

    public GameObject opponent;

    [SerializeField]
    float fwdSpeed = 5.0f;
    [SerializeField]
    float backSpeed = 5.0f;

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
            if (!m_engine) Debug.LogError (NoMovementEngineError);
#endif
        }
        if (!m_anim) {
            m_anim = GetComponent<Animator> ();
#if UNITY_EDITOR
            if (!m_anim) Debug.LogError (NoAnimatorError);
#endif
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update () {

    }
}
