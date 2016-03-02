using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Fighter Controls", menuName = "Fighter Controls")]
public class FighterInputs : ScriptableObject {
    [SerializeField]
    public string HorizontalAxis = "Horizontal";
    [SerializeField]
    public string Jump = "Jump";
    [SerializeField]
    public string LightAttack = "Light";
    [SerializeField]
    public string MediumAttack = "Medium";
    [SerializeField]
    public string HeavyAttack = "Heavy";
}
