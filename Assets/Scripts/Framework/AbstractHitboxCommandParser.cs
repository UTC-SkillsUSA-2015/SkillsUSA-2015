using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public abstract class AbstractHitboxCommandParser<THitbox> : AbstractCommandParser
    where THitbox : AbstractHitbox {

    protected IDictionary<string, THitbox> m_hitboxes = new Dictionary<string, THitbox> ();
    protected IDictionary<string, AttackData> m_attacks = new Dictionary<string, AttackData> ();

    string kRepeatedNameMessage {
        get {
            return "{0} {1} has the same name as another {0} being passed to the AttackHandler on {2}";
        }
    }

    string kInvalidNameMessage {
        get {
            return "{0} \"{1}\" contains an invalid character \"{2}\" in name.";
        }
    }

    public abstract Regex kInvalidNameCharacters {
        get;
    }

    [SerializeField]
    protected AttackData[] kAttacks;

    // Use this for initialization
    protected void Start () {
        IterateAndAdd (GetComponentsInChildren<THitbox> (), ref m_hitboxes, "Hitbox");
        IterateAndAdd (kAttacks, ref m_attacks, "AttackData");
        DerivedStart ();
    }

    /// <summary>
    /// Default implementation does nothing;
    /// can be overridden if subclass needs to do
    /// more than the default component retrieval
    /// in Start()
    /// </summary>
    protected virtual void DerivedStart () { }

    void IterateAndAdd<T> (IEnumerable<T> items, ref IDictionary<string, T> dict, string type)
        where T : UnityEngine.Object {
        foreach (var obj in items) {
            var invalid = kInvalidNameCharacters.Match (obj.name);
            if (invalid.Success)
                Debug.LogError (
                    string.Format (
                        kInvalidNameMessage,
                        type,
                        obj.name,
                        Regex.Unescape (invalid.Value) // Turn a newline into \n, etc
                        )
                    );
            else if (dict.ContainsKey (obj.name))
                throw new Exception (
                    string.Format (
                        kRepeatedNameMessage,
                        type,
                        obj.name,
                        gameObject.name
                        )
                    );
            else
                dict.Add (obj.name, obj);
        }
    }
}
