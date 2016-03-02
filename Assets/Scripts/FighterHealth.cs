using UnityEngine;
using System.Collections;

public class FighterHealth : MonoBehaviour {
    [SerializeField]
    uint maxHealth;

    uint m_currentHealth;

    /// <summary>
    /// The current health of the fighter.
    /// </summary>
    public uint CurrentHealth {
        get {
            return m_currentHealth;
        }
        set {

        }
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}