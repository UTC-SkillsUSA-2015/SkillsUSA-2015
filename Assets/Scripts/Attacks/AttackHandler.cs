﻿using UnityEngine;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Manages the activation of attacks through a Mecanim-friendly string-parsing interface.
/// </summary>
public class AttackHandler : MonoBehaviour {
    [SerializeField]
    AttackData[] attacks;

    IDictionary<string, FighterHitbox> m_hitboxes = new Dictionary<string, FighterHitbox> ();
    IDictionary<string, AttackData> m_attacks = new Dictionary<string, AttackData> ();
    
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
            return "{0} {1} has the same name as another {0} being passed to the HitManager on {2}";
        }
    }

    string FailedCommandErrorMessage(string command) {
        return "Invalid command string \"" + command + "\" passed to " + gameObject.name + "'s AttackHandler";
    }

    // Use this for initialization
    void Start () {
        IterateAndAdd (GetComponentsInChildren<FighterHitbox>(), ref m_hitboxes, "Hitbox");
        IterateAndAdd (attacks, ref m_attacks, "AttackData");
    }

    // Update is called once per frame
    void Update () {

    }

    public void ParseString (string command) {
        if (!reggie.IsMatch (command)) {
            throw new Exception (FailedCommandErrorMessage(command));
        }
        else {
            var groups = reggie.Match (command).Groups;
            var attackName = groups["Attack"].Value;
            var hitboxNames = groups["Hitboxes"].Captures;

            var attack = m_attacks[attackName];
            for (int i = 0; i < hitboxNames.Count; i++) {
                m_hitboxes[hitboxNames[i].Value].Attack (attack);
            }
        }
    }

    void IterateAndAdd<T> (IEnumerable<T> items, ref IDictionary<string, T> dict, string type)
        where T : UnityEngine.Object {
        foreach (var obj in items) {
            if (dict.ContainsKey(obj.name)) {
                throw new Exception (string.Format (RepeatedNameMessage, type, obj.name, gameObject.name));
            }
            else {
                dict.Add (obj.name, obj);
            }
        }
    }
}