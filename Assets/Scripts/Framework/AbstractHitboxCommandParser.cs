using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public abstract class AbstractComponentCommandParser<TComponent> : AbstractCommandParser
    where TComponent : Component {

    protected IDictionary<string, TComponent> m_hitboxes = new Dictionary<string, TComponent> ();
    protected IDictionary<string, AttackData> m_attacks = new Dictionary<string, AttackData> ();

    string kRepeatedNameMessage {
        get {
            return "{0} {1} has the same name as another {0} being passed to the " + this.GetType().Name + " on {2}";
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
        IterateAndAdd (GetComponentsInChildren<TComponent> (), ref m_hitboxes);
        IterateAndAdd (kAttacks, ref m_attacks);
        DerivedStart ();
    }

    /// <summary>
    /// Default implementation does nothing;
    /// can be overridden if subclass needs to do
    /// more than the default component retrieval
    /// in Start()
    /// </summary>
    protected virtual void DerivedStart () { }

    void IterateAndAdd<T> (IEnumerable<T> items, ref IDictionary<string, T> dict)
        where T : UnityEngine.Object {
        foreach (var obj in items) {
            var invalid = kInvalidNameCharacters.Match (obj.name);
            if (invalid.Success)
                Debug.LogError (
                    string.Format (
                        kInvalidNameMessage,
                        obj.GetType().Name,
                        obj.name,
                        invalid.Value
                        )
                    );
            else if (dict.ContainsKey (obj.name))
                throw new Exception (
                    string.Format (
                        kRepeatedNameMessage,
                        obj.GetType().Name,
                        obj.name,
                        gameObject.name
                        )
                    );
            else
                dict.Add (obj.name, obj);
        }
    }
}
