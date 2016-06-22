using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {
    [SerializeField]
    WinConditions winning;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("AP1")) {
            if (winning.ended)
                winning.restart ();
        }
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("StartButton")) {
			if (winning.ended)
				winning.quit ();
		}
	}
}
