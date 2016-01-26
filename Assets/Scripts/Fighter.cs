using UnityEngine;

/// <summary>
/// The Fighter class is the wrapper which commands all other components
/// to make the game object run.
/// </summary>
[RequireComponent (typeof (Animator))]
public class Fighter : MonoBehaviour {
    [SerializeField]
    Abstract2DPlatformEngine m_engine;
}
