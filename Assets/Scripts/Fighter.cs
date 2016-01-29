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

    // Start is called just before any of the Update methods is called the first time
    public void Start () {
        if (!m_engine) {
            m_engine = GetComponent<Abstract2DPlatformEngine> ();
#if UNITY_EDITOR
            if (!m_engine) Debug.LogError ("Could not find movement engine for Fighter script on "
                + gameObject.name);
#endif
        }
        if (!m_anim) {
            m_anim = GetComponent<Animator> ();
#if UNITY_EDITOR
            if (!m_anim) Debug.LogError ("Could not find animator for Fighter script on "
                + gameObject.name);
#endif
        }
    }

    // Update is called every frame, if the MonoBehaviour is enabled
    public void Update () {

    }
}
