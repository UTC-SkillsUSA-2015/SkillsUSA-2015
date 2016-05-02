using UnityEngine;
using System.Collections;

public class CreditRoll : MonoBehaviour {

    [SerializeField]
    Animator anim;

    void OnEnable()
    {
        anim.Play("CreditRoll");
    }
}
