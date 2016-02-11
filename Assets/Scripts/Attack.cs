using UnityEngine;
using System.Collections;

public struct Attack {
    /// <summary>
    /// The properties of the attack.
    /// </summary>
    public AttackData data;
    /// <summary>
    /// The team this attack came from.
    /// </summary>
    public int team;
    /// <summary>
    /// The id of this attack; not expected to be meaningful beyond
    /// differentiating it with other attacks.
    /// </summary>
    public int id;
}
