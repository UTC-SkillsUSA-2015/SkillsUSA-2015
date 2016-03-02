using UnityEngine;
using System.Collections;

public class Attack {
    /// <summary>
    /// The properties of the attack.
    /// </summary>
    public readonly AttackData kData;
    /// <summary>
    /// The team this attack came from.
    /// </summary>
    public readonly int kTeam;
    /// <summary>
    /// The id of this attack; not expected to be meaningful beyond
    /// differentiating it with other attacks.
    /// </summary>
    public readonly int kId;
    /// <summary>
    /// The damage multiplier applied to the attack. Affected when blocked,
    /// or when using higher-powered characters.
    /// </summary>
    public float damageMultiplier;
    /// <summary>
    /// Affects the launch vector with Vector2.Scale
    /// </summary>
    public Vector2 launchScale;

    public int TotalDamage {
        get {
            return (int) (kData.Dmg * damageMultiplier);
        }
    }
    public Vector2 TotalLaunch {
        get {
            return Vector2.Scale (kData.Launch, launchScale);
            // This is wrong: return kData.Launch.Scale (launchScale);
        }
    }

    public Attack (AttackData data, int team, int id, float damageMult = 1.00f,
        float xKnockbackMult = 1.00f, float yKnockbackMult = 1.00f) {
        kData = data;
        kTeam = team;
        kId = id;
        damageMultiplier = damageMult;
        launchScale = new Vector2 (xKnockbackMult, yKnockbackMult);
    }

    public static bool operator == (Attack left, Attack right) {
        return left.kData == right.kData && left.kTeam == right.kTeam && left.kId == right.kId;
    }
    public static bool operator != (Attack left, Attack right) {
        return left.kData != right.kData || left.kTeam != right.kTeam || left.kId != right.kId;
    }
    public override bool Equals (object obj) {
        if (obj.GetType () == typeof (Attack)) {
            var atk = (Attack) obj;
            return kData == atk.kData && kTeam == atk.kTeam && kId == atk.kId;
        }
        else {
            return false;
        }
    }
    public override int GetHashCode () {
        var hash = (kData.GetHashCode () + kId);
        hash *= (int) (10 * damageMultiplier);
        hash <<= Mathf.Abs (kTeam);
        return hash;
    }
}
