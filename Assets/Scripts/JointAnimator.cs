using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class JointAnimator : MonoBehaviour {

    public Joints mabones;

    [Range(0, 135)]
    public float LeftLowerArmANGLE;    

    [Range(0, 135)]
    public float RightLowerArmANGLE;    

    [Range(-90, 90)]
    public float LeftShoulderANGLE;    

    [Range(-90, 90)]
    public float RightShoulderANGLE;   

    [Range(-45, 10)]
    public float LeftHandANGLE;

    [Range(-45, 10)]
    public float RightHandANGLE;   

    [Range(-30, 70)]
    public float UpperTorsoANGLE;    

    [Range(-10, 45)]
    public float WaistANGLE;   

    [Range(-30, 80)]
    public float LeftThighANGLE;

    [Range(-30, 80)]
    public float RightThighANGLE;   

    [Range(-135, 0)]
    public float LeftLowerLegANGLE;    

    [Range(-135, 0)]
    public float RightLowerLegANGLE;    

    [Range(-70, 0)]
    public float LeftFootANGLE;    

    [Range(-70, 0)]
    public float RightFootANGLE;    

    [Range(-60, 60)]
    public float HeadANGLE;   

    void Update()
    {
        mabones.LeftLowerArm.transform.localRotation = Quaternion.Euler(0, 0, LeftLowerArmANGLE);
        mabones.RightLowerArm.transform.localRotation = Quaternion.Euler(0, 0, RightLowerArmANGLE);
        mabones.LeftShoulder.transform.localRotation = Quaternion.Euler(0, 0, LeftShoulderANGLE);
        mabones.RightShoulder.transform.localRotation = Quaternion.Euler(0, 0, RightShoulderANGLE);
        mabones.LeftHand.transform.localRotation = Quaternion.Euler(0, 0, LeftHandANGLE);
        mabones.RightHand.transform.localRotation = Quaternion.Euler(0, 0, RightHandANGLE);
        mabones.UpperTorso.transform.localRotation = Quaternion.Euler(0, 0, UpperTorsoANGLE);
        mabones.Waist.transform.localRotation = Quaternion.Euler(0, 0, WaistANGLE);
        mabones.LeftThigh.transform.localRotation = Quaternion.Euler(0, 0, LeftThighANGLE);
        mabones.RightThigh.transform.localRotation = Quaternion.Euler(0, 0, RightThighANGLE);
        mabones.LeftLowerLeg.transform.localRotation = Quaternion.Euler(0, 0, LeftLowerLegANGLE);
        mabones.RightLowerLeg.transform.localRotation = Quaternion.Euler(0, 0, RightLowerLegANGLE);
        mabones.LeftFoot.transform.localRotation = Quaternion.Euler(0, 0, LeftFootANGLE);
        mabones.RightFoot.transform.localRotation = Quaternion.Euler(0, 0, RightFootANGLE);
        mabones.Head.transform.localRotation = Quaternion.Euler(0, 0, HeadANGLE);
    }
}

[System.Serializable]
public class Joints
{
    public GameObject LeftLowerArm;

    public GameObject RightLowerArm;

    public GameObject LeftShoulder;

    public GameObject RightShoulder;

    public GameObject LeftHand;

    public GameObject RightHand;

    public GameObject UpperTorso;

    public GameObject Waist;

    public GameObject LeftThigh;

    public GameObject RightThigh;

    public GameObject LeftLowerLeg;

    public GameObject RightLowerLeg;

    public GameObject LeftFoot;

    public GameObject RightFoot;

    public GameObject Head;

}
