using UnityEngine;
using System.Collections;
using System;

public class DebugAttackHitbox : AbstractAttackingHitbox {
    Attack m_currentAttack;
    int m_frameTimer;

    protected override int Team {
        get {
            return m_team;
        }
    }

    [SerializeField]
    int m_team;

    public override void Attack (AttackData attack) {
        Debug.Log ("Began attack " + attack.name);
        
    }

    public override void Hit (Attack attack) {
        Debug.Log ("Hit by " + attack.kData.name + " for " + attack.TotalDamage + "dmg");
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
