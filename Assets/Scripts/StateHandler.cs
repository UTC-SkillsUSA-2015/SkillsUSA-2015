using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using State = AbstractHitbox.State;

public class StateHandler : AbstractHitboxCommandParser<AbstractAttackingHitbox> {
    #region Hiding
    const string kFormat = @"(?<=^|;|; )[Aa]pply (?:(?:[Aa]ttack (?<Attack>[\w_-]+))|(?:[Ss]tate (?<State>[\w_-]+))) to (?:(?:[Hh]itbox(?:es)? (?:(?:(?<Hitbox>[\w_-]+)(?:, )?)+|$))+|(?<All>all [Hh]itboxes);?)(?=$|;)";
    #endregion
    const string kInvalidChars = @"[^\w_-]";

    readonly Regex kFormatMatcher = new Regex (kFormat);
    IDictionary<string, State> kStates;

    public override Regex kInvalidNameCharacters {
        get {
            return new Regex (kInvalidChars);
        }
    }

    public void ParseStringWrapper(string command) {
        ParseString (command);
    }

    public override void ParseString (string command) {
        var matches = kFormatMatcher.Matches (command);
        foreach (Match match in matches) {
            var groups = match.Groups;
            var allGroup = groups["All"];
            var hitboxGroup = groups["Hitbox"];
            var stateGroup = groups["State"];
            var attackGroup = groups["Attack"];

            var boxKeys = allGroup.Success ?
                m_hitboxes.Keys :
                CaptureStringIterator(hitboxGroup.Captures);
            foreach (var key in boxKeys) {
                var hitbox = m_hitboxes[key];
                if (stateGroup.Success) {
                    hitbox.state = (State) Enum.Parse (typeof (State), stateGroup.Value); 
                }
                else {
                    hitbox.Attack (m_attacks[attackGroup.Value]);
                }
            }
        }
    }

    static IEnumerable<string> CaptureStringIterator (CaptureCollection captures) {
        foreach (Capture c in captures) {
            yield return c.Value;
        }
    }
}
