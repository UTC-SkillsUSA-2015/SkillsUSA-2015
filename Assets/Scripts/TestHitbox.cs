using UnityEngine;
using System.Collections;
using System;

public class TestHitbox : AbstractHitbox {
    public override void Hit (Attack attack) {
		Debug.Log ("I've been hit for " + attack.kData.Dmg + " damage by " + attack.kData.name + "!!", gameObject);
		Debug.Log ("BLAM");
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
