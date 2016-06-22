using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// InputAnalyzer looks at recent inputs and puts them into more
// readable format for other components to use
public class InputAnalyzer : ScriptableObject {
    [SerializeField]
    int frameLeniency = 20;

    /// <summary>
    /// Read-only field that returns interpretations of the recent inputs, in order of
    /// decreasing complexity. A quarter-circle-back + light attack will
    /// precede a back + light attack, which will then precede a single light attack.
    /// </summary>
    //public IEnumerator interpretedInputs {
    //    get {

    //    }
    //}

    /// <summary>
    /// Returns a raw list of the recent inputs, with no analysis going on beforehand.
    /// List will be ordered from most recent to last.
    /// </summary>
    //public IList recentInputs {
    //    get {
             
    //    }
    //}

    Queue<string> m_inputs = new Queue<string> ();
    Stack<string> m_interpretations = new Stack<string> ();

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
