using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinnerStatsNew : MonoBehaviour {

	public Canvas MainCanvas;
	public GameObject EndCanvas;
	private static int p1Health;
	public Text p1HealthText;
	private static int p2Health;
	public Text p2HealthText;
	public GameObject p1Win;
	public GameObject p2Win;
	public GameObject middleP1Win;
	public GameObject middleP2Win;
	public GameObject p1First;
	public GameObject p1Second;
	public GameObject p2First;
	public GameObject p2Second;
	public GameObject tie;
	public GameObject suddenDeathText;
	public GameObject p1sdWin;
	public GameObject p2sdWin;

	void Start () 
	{
		EndCanvas.SetActive(false);
		p1Health = 100;
		Setp1HealthText ();
		p2Health = 100;
		Setp2HealthText ();
	}

	void Update () 
	{
		if (p1Health < 0) 
		{
			p2Win.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p2Health < 0) 
		{
			p1Win.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p1Win.activeSelf && p2Health == 0) 
		{
			middleP1Win.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p2Win.activeSelf && p1Health == 0) 
		{
			middleP2Win.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (middleP1Win.activeSelf) 
		{
			p1First.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
			p1First.SetActive (true);
			p2Second.SetActive (true);
			MainCanvas.enabled = true;
			EndCanvas.SetActive(true);
		}
		if (middleP2Win.activeSelf) 
		{
			p2First.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
			p2First.SetActive (true);
			p1Second.SetActive (true);
			MainCanvas.enabled = true;
			EndCanvas.SetActive(true);
		}
		if (p1Win.activeSelf && p2Win.activeSelf && p1Health == 20 && p2Health == 20) 
		{
			tie.SetActive (true);
			middleP2Win.SetActive (false);
			middleP1Win.SetActive (false);
			middleP2Win.SetActive (false);
			suddenDeathText.SetActive (true);
			p1Health = 100;
			Setp1HealthText ();
			p2Health = 100;
			Setp2HealthText ();
		}
		if (p1sdWin.activeSelf) 
		{
			EndCanvas.SetActive (true);
			p1First.SetActive (true);
			p2Second.SetActive (true);
			p1sdWin.SetActive (true);
		}
		if (p2sdWin.activeSelf) 
		{
			EndCanvas.SetActive (true);
			p2First.SetActive (true);
			p1Second.SetActive (true);
			p2sdWin.SetActive (true);
			middleP2Win.SetActive (false);
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
	public void Tie()
	{
		p1Health = p1Health - 20;
		Setp1HealthText ();
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
