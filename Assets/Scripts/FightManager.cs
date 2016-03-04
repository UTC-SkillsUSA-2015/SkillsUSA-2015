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
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (!winning.started)
                winning.FIGHTEXCLAMATIONPOINT ();
            else if (winning.ended)
                winning.restart ();
        }
	}
}
