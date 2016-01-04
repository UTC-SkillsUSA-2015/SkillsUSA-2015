using UnityEngine;

/// <summary>
/// The Fighter class is the wrapper which commands all other components
/// to make the game object run.
/// </summary>
[RequireComponent (typeof (Animator))]
[RequireComponent (typeof (ISimplePlatformEngine2D))]
public class Fighter : MonoBehaviour {
}
