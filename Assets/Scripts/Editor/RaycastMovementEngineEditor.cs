using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (RaycastMovementEngine))]
public class RaycastMovementEngineEditor : Editor {
    SerializedProperty leftCornerProp;
    SerializedProperty rightCornerProp;

    void OnEnable () {
        leftCornerProp = serializedObject.FindProperty ("leftCorner");
        rightCornerProp = serializedObject.FindProperty ("rightCorner");
    }
}
