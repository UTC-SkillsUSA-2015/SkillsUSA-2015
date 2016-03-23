using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Manages the activation of attacks through a Mecanim-friendly string-parsing interface.
/// </summary>
public class AttackHandler : AbstractHitboxCommandParser<FighterHitbox> {
    
#if UNITY_EDITOR
    [SerializeField]
    bool debug;
#endif

    /// <summary>
    /// Translates into matching strings of the following format:
    /// Attack: [Attack name]; Hitboxes: [Hitbox name 1], [Hitbox name 2], (etc);
    /// Replace bracketed names with the respective names. Names can only include letters,
    /// numbers, spaces and underscores. Name must be in the respective array for this
    /// AttackHandler.
    /// All spaces are optional.
    /// Examples of valid commands:
    /// Attack: Punch; Hitboxes: Fist, Wrist, Forearm;
    /// Attack:Punch;Hitboxes:Fist,Wrist,Forearm;
    /// Attack: Heavy_Punch; Hitboxes: Left_Fist, Left_Wrist, Left_Forearm;
    /// Attack: Heavy Punch; Hitboxes: Left Fist, Left Wrist, Left Forearm;
    /// </summary>
    const string CommandRegex = @"^Attack: *(?<Attack>[\w_ ]+); *Hitboxes: *(?: *(?<Hitboxes>[\w_ ]+),? *)+;$";

    Regex reggie = new Regex (CommandRegex);

    /// <summary>
    /// Returns a formattable string used if two objects have the same name in one category.
    /// Index 0 is the type of object, 1 is the name, and 2 is the name of the object
    /// this script is on.
    /// </summary>
    string RepeatedNameMessage {
        get {
            return "{0} {1} has the same name as another {0} being passed to the AttackHandler on {2}";
        }
    }

    public override Regex kInvalidNameCharacters {
        get {
            return new Regex (@"[^\w_ ]");
        }
    }

    // Use this for initialization
    protected override void DerivedStart () {
#if UNITY_EDITOR
        if (debug) {
            DebugKeys ("Hitboxes", m_hitboxes);
            DebugKeys ("Attacks", m_attacks);
        }
#endif
    }

    public override void ParseString (string command) {
        if (!reggie.IsMatch (command)) {
            throw new Exception (FailedCommandErrorMessage (command));
        }
        else {
            var groups = reggie.Match (command).Groups;
            var attackName = groups["Attack"].Value;
            var hitboxNames = groups["Hitboxes"].Captures;

            string key = "";
            string dict = "";
            try {
                key = attackName;
                dict = "Attack";
                var attack = m_attacks[key];
                dict = "Hitbox";
                for (int i = 0; i < hitboxNames.Count; i++) {
                    key = hitboxNames[i].Value;
                    m_hitboxes[key].Attack (attack);
                }
            }
            catch (KeyNotFoundException knfe) {
#if UNITY_EDITOR
                Debug.LogException (new Exception ("Could not find key '" + key + "' in " +
                    dict + " dictionary", knfe));
                if (debug) {
                    DebugKeys ("Hitboxes", m_hitboxes);
                    DebugKeys ("Attacks", m_attacks);
                }
#endif
            }
        }
    }

    void DebugKeys<T, U> (string name, IDictionary<T, U> dict) {
        var temp = name + ":\n";
        foreach (var str in dict.Keys) {
            temp += "'" + str + "'\n";
        }
        Debug.Log (temp);
    }

    void IterateAndAdd<T> (IEnumerable<T> items, ref IDictionary<string, T> dict, string type)
        where T : UnityEngine.Object {
        foreach (var obj in items) {
            if (dict.ContainsKey (obj.name)) {
                throw new Exception (string.Format (RepeatedNameMessage, type, obj.name, gameObject.name));
            }
            else {
                dict.Add (obj.name, obj);
            }
        }
    }
}
