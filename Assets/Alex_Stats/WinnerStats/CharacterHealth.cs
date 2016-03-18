using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterHealth : MonoBehaviour {

	private static int p1Health;
	public Text p1HealthText;
	private static int p2Health;
	public Text p2HealthText;
	public GameObject p1CM01;
	public GameObject p1CM02;
	public GameObject p1CM03;
	public GameObject p2CM01;
	public GameObject p2CM02;
	public GameObject p2CM03;

	void Start () 
	{
		p1Health = 100;
		Setp1HealthText ();
		p2Health = 100;
		Setp2HealthText ();
	}

	void Update () 
	{
		if (p1Health == 0) 
		{
			p2CM01.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p2Health == 0) 
		{
			p1CM01.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p1CM01.activeSelf && p2Health == 0) 
		{
			p1CM02.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p1CM02.activeSelf && p2Health == 0) 
		{
			p1CM03.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p2CM01.activeSelf && p1Health == 0) 
		{
			p2CM02.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p2CM02.activeSelf && p1Health == 0) 
		{
			p2CM03.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
	}
	public void Hurtp1()
	{
		p1Health = p1Health - 20;
		Setp1HealthText ();
	}
	public void Hurtp2()
	{
		p2Health = p2Health - 20;
		Setp2HealthText ();
	}
	void Setp1HealthText()
	{
		p1HealthText.text = "P1 Health: " + p1Health.ToString ();
	}
	void Setp2HealthText()
	{
		p2HealthText.text = "P2 Health: " + p2Health.ToString ();
	}
}
