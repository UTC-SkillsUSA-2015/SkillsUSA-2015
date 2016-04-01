using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Fighter Controls", menuName = "Fighter Controls")]
public class FighterInputs : ScriptableObject {
    [SerializeField]
    public string HorizontalAxis;
    [SerializeField]
    public string Jump;
    [SerializeField]
    public string LightAttack;
    [SerializeField]
    public string MediumAttack;
    [SerializeField]
    public string HeavyAttack;
}
