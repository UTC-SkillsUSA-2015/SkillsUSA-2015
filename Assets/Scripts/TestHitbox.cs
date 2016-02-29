using UnityEngine;
using System.Collections;
using System;

public class TestHitbox : AbstractHitbox {
    public override void Hit (Attack attack) {
		Debug.Log ("I've been for " + attack.kData.Dmg + " by " + attack.kData.name + "!!", gameObject);
    }

    public override void OnTriggerEnter2D (Collider2D collision) {
        // blah
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
