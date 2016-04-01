using UnityEngine;
using System.Collections;

public abstract class AbstractAttackingHitbox : AbstractHitbox {
    public abstract void Attack (AttackData attack);
    /// <summary>
    /// Utility method to quickly create an attack from some data.
    /// </summary>
    /// <param name="data">The AttackData to create an attack for.</param>
    /// <returns>An Attack using the given data.</returns>
    protected Attack GenerateAttack (AttackData data, float damageMult = 1.00f,
        float xKnockbackMult = 1.00f, float yKnockbackMult = 1.00f) {
        return new Attack (data, Team, GenerateID (data),
            damageMult, xKnockbackMult, yKnockbackMult);
    }
    /// <summary>
    /// Utility method to generate attack IDs.
    /// </summary>
    /// <param name="data">The data to create an id for.</param>
    /// <returns>An entirely unique id for the data.</returns>
    protected virtual int GenerateID (AttackData data) {
        var id = data.GetHashCode () * 23;
        id <<= data.Priority;
        id <<= 5;
        id *= Time.frameCount;
        return id;
    }
}
