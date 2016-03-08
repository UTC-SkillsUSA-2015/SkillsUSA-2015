using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class JointAnimator : MonoBehaviour {

    [Range(0, 135)]
    public float LeftLowerArmANGLE;
    [SerializeField]
    GameObject LeftLowerArm;

    [Range(0, 135)]
    public float RightLowerArmANGLE;
    [SerializeField]
    GameObject RightLowerArm;

    [Range(-90, 90)]
    public float LeftShoulderANGLE;
    [SerializeField]
    GameObject LeftShoulder;

    [Range(-90, 90)]
    public float RightShoulderANGLE;
    [SerializeField]
    GameObject RightShoulder;

    [Range(-45, 10)]
    public float LeftHandANGLE;
    [SerializeField]
    GameObject LeftHand;

    [Range(-45, 10)]
    public float RightHandANGLE;
    [SerializeField]
    GameObject RightHand;

    [Range(-30, 70)]
    public float UpperTorsoANGLE;
    [SerializeField]
    GameObject UpperTorso;

    [Range(-10, 45)]
    public float WaistANGLE;
    [SerializeField]
    GameObject Waist;

    [Range(-30, 80)]
    public float LeftThighANGLE;
    [SerializeField]
    GameObject LeftThigh;

    [Range(-30, 80)]
    public float RightThighANGLE;
    [SerializeField]
    GameObject RightThigh;

    [Range(-135, 0)]
    public float LeftLowerLegANGLE;
    [SerializeField]
    GameObject LeftLowerLeg;

    [Range(-135, 0)]
    public float RightLowerLegANGLE;
    [SerializeField]
    GameObject RightLowerLeg;

    [Range(-70, 0)]
    public float LeftFootANGLE;
    [SerializeField]
    GameObject LeftFoot;

    [Range(-70, 0)]
    public float RightFootANGLE;
    [SerializeField]
    GameObject RightFoot;

    [Range(-60, 60)]
    public float HeadANGLE;
    [SerializeField]
    GameObject Head;

    void Update()
    {

    }
}
