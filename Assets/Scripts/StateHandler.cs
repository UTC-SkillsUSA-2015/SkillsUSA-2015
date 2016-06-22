using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using State = AbstractHitbox.State;

/// <summary>
/// More generalized version of the now deprecated AttackHandler.
/// Accepts commands in the following formats: <para />
/// - "Apply State &lt;State&gt; to Hitbox &lt;Hitbox&gt;"<para />
/// - "apply state &lt;State&gt; to hitbox &lt;Hitbox&gt;;"<para />
/// - "Apply state &lt;State&gt; to all hitboxes;"<para />
/// - "Apply attack &lt;Attack&gt; to hitbox &lt;Hitbox&gt;"<para />
/// - "Apply state &lt;State&gt; to hitboxes &lt;Hitbox 1&gt;, &lt;Hitbox 2&gt;, &lt;Hitbox 3&gt;"<para />
/// - "Apply state &lt;State&gt; to all hitboxes; apply attack &lt;Attack&gt; to hitbox &lt;Hitbox&gt;"
/// </summary>
public class StateHandler : AbstractComponentCommandParser<AbstractAttackingHitbox> {
    #region Hiding the monstrosity of the format string
    const string kLookBehind = @"(?<=^|;|; )";
    const string kLookAhead = @"(?=$|;)";
    const string kMainRegex = @"[Aa]pply (?:(?:[Aa]ttack (?<Attack>[\w_-]+))|(?:[Ss]tate (?<State>[\w_-]+))) to (?:(?:[Hh]itbox(?:es)? (?:(?:(?<Hitbox>[\w_-]+)(?:, )?)+|$))+|(?<All>all [Hh]itboxes)?)";
    const string kFormatMatcher = kLookBehind + kMainRegex + kLookAhead;
    const string kExtender = @"($|; *)";
    const string kValidityChecker = @"^(" + kLookBehind + kMainRegex + kExtender + @")+$";
    #endregion
    const string kInvalidChars = @"[^\w_-]";

    readonly Regex kMatcher = new Regex (kFormatMatcher);
    readonly Regex kValidator = new Regex (kValidityChecker);

    IDictionary<string, State> kStates;

    public override Regex kInvalidNameCharacters {
        get {
            return new Regex (kInvalidChars);
        }
    }

    /// <summary>
    /// Wraps a function call to ParseString to allow the Unity pre-5.4 animator
    /// call the method in an AnimationEvent.
    /// </summary>
    /// <param name="command">The command to parse.</param>
    public void ParseStringWrapper (string command) {
        ParseString (command);
    }

    /// <summary>
    /// Parses the input command and applies the specified effects
    /// as necessary. May throw an error if command is not a valid
    /// command string.
    /// </summary>
    /// <param name="command">The command to parse</param>
    /// <exception cref="ArgumentException">Thrown if the command string does not fulfill the format.</exception>
    public override void ParseString (string command) {
        var matches = kMatcher.Matches (command);
        if (!kValidator.IsMatch (command)) {
            throw new ArgumentException (FailedCommandErrorMessage(command));
        }
        else {
            foreach (Match match in matches) {
                var groups = match.Groups;
                var allGroup = groups["All"];
                var hitboxGroup = groups["Hitbox"];
                var stateGroup = groups["State"];
                var attackGroup = groups["Attack"];

                var boxKeys = allGroup.Success ?
                    m_hitboxes.Keys :
                    CaptureStringIterator (hitboxGroup.Captures);
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
    }

    static IEnumerable<string> CaptureStringIterator (CaptureCollection captures) {
        foreach (Capture c in captures) {
            yield return c.Value;
        }
    }
}
