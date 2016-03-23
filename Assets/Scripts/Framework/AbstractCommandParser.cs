using UnityEngine;

public abstract class AbstractCommandParser : MonoBehaviour, ICommandParser {
    public string FailedCommandErrorMessage (string command) {
        return "Invalid command string \"" + command + "\" passed to " + gameObject.name + "'s AttackHandler";
    }

    public abstract void ParseString (string command);
}
