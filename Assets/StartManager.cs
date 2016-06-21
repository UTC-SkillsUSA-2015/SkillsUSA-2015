using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour {

	public Animator start;

	bool flag = false;
	public GameObject Logo;
	public GameObject main;
	public GameObject manager;

	void Start(){
		main.SetActive (false);
		Logo.SetActive (true);
		manager.SetActive (false);
	}

	void Update(){
		if (!flag) {
			if (Input.GetButtonDown ("StartButton") || Input.GetKeyDown (KeyCode.Return)) {
				start.SetTrigger ("Start");
				flag = true;
			}
		}
	}

	public void showMenu(){
		main.SetActive (true);
		manager.SetActive (true);
	}

	public void HideLogo(){
		Logo.SetActive (false);
	}
}
