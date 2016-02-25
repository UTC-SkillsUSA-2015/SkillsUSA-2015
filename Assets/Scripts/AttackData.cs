using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AttackData : ScriptableObject {
    // Note: Values of the AttackData are separated into fields and their property
    // encapsulations. Fields are accessed by the designers through Inspector;
    // Properties are accessed by other scripts, making the values in the
    // object unmodifiable.
    #region Fields
    /// <summary>
    /// The priority of the attack. Higher priorities will cancel out lower
    /// priorities. Equal priorities will cancel out each other.
    /// </summary>
    [SerializeField]
    int m_priority = 0;
    /// <summary>
    /// The damage dealt by the attack.
    /// </summary>
    [SerializeField]
    int m_dmg = 0;
    /// <summary>
    /// The amount of chip damage the attack deals.
    /// </summary>
    [SerializeField]
    [Range(0,1)]
    float m_chip = 0;
    /// <summary>
    /// The velocity the hit fighter takes on when struck by this attack.
    /// </summary>
    [SerializeField]
    Vector2 m_launch = Vector2.zero;
    /// <summary>
    /// Whether the attack puts the opponent into launch state (no cancel),
    /// or merely damaged state (cancellable).
    /// </summary>
    [SerializeField]
    bool m_launchState = false;
    #endregion
    #region Properties
    public int Priority {
        get {
            return m_priority;
        }
    }

    public int Dmg {
        get {
            return m_dmg;
        }
    }

    public float Chip {
        get {
            return m_chip;
        }
    }

    public Vector2 Launch {
        get {
            return m_launch;
        }
    }

    public bool LaunchState {
        get {
            return m_launchState;
        }
    }
    #endregion

    public override int GetHashCode () {
        int istof;
        istof = (m_dmg + (347 << Mathf.Abs (m_priority))) * 54;
        istof += this.name.GetHashCode () >> 2;
        istof *= (m_priority * 67 + (int) (m_chip * 97570));
        istof += (int) (m_launch.magnitude * (100 * m_chip) * (m_launchState ? 1 : -1));
        istof *= 789 << (int) (m_chip * 10);
        return istof;
    }
}
