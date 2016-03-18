using UnityEngine;
using System.Collections;

public class CountDown : MonoBehaviour 
{
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject fight;
	public GameObject block;

	void Start () 
	{
		StopCoroutine (Countdwn ());
		StartCoroutine (Countdwn ());
	}
	
	IEnumerator Countdwn () 
	{
		yield return new WaitForSeconds (0.5f);
		three.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		three.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		two.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		two.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		one.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		one.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		fight.SetActive (true);
		yield return new WaitForSeconds (1f);
		fight.SetActive (false);
		block.SetActive (false);
	}
}
