using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets;

public class ScreenCap : MonoBehaviour {

	public GameObject flash;

	void Start()
	{
		flash.SetActive(false);
		GetComponent<GrayScale> ().enable = false;
	}
	void Capture ()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			Snap();
		}
	}

	IEnumerator Snap()
	{
		flash.SetActive (true);
		Time.timeScale = 0;

		flash.SetActive(false);
		yield return new WaitForSeconds (3);
		Time.timeScale = 1;
	}
}