using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Fighter Controls", menuName = "Fighter Controls")]
public class FighterInputs : ScriptableObject {
    public string[] HorizontalAxis;
    public string[] VerticalAxis;
    public string[] LightAttack;
    public string[] MediumAttack;
    public string[] HeavyAttack;

    public float HorizontalInput {
        get {
            return firstAxis (HorizontalAxis);
        }
    }
    public float VerticalInput {
        get {
            return firstAxis (VerticalAxis);
        }
    }
    public bool LightInput {
        get {
            return firstButton (LightAttack);
        }
    }
    public bool MediumInput {
        get {
            return firstButton (MediumAttack);
        }
    }
    public bool HeavyInput {
        get {
            return firstButton (HeavyAttack);
        }
    }

    private float firstAxis(string[] axes) {
        var i = 0f;
        foreach (var axis in axes) {
            i = Input.GetAxisRaw (axis);
            Debug.Log ("Axis " + axis + " returned " + i);
            if (i != 0)
                break;
        }
        return i;
    }

    private bool firstButton (string[] buttons) {
        var i = false;
        foreach (var button in buttons) {
            i = Input.GetButtonDown (button);
            if (i)
                break;
        }
        return i;
    }
}
