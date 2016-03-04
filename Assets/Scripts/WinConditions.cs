using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour {

    [SerializeField]
    HealthBar P1Script;

    [SerializeField]
    HealthBar P2Script;

    [SerializeField]
    GameObject[] winTexts;

    [SerializeField]
    GameObject startCanvas;

    [SerializeField]
    GameObject endCanvas;

    int winText = 0;

    float P1Health;
    float P2Health;

    [SerializeField]
    Timer timer;

    float timeer;

    bool playerOneWins = false;
    bool playerTwoWins = false;
    bool tie = false;
    public bool started { get; private set; }
    public bool ended { get; private set; }

	void Start () {
        Time.timeScale = 0;
        endCanvas.SetActive(false);
        startCanvas.SetActive(true);
	}
	
	void Update () {
        timeer = timer.fseconds;
        P1Health = (float)P1Script.CurrentHealth;
        P2Health = (float)P2Script.CurrentHealth;

        if (P1Health == 0 || P2Health == 0) {
            Debug.Log ("WORK DAMMMIT!");
            CheckWinner ();
        }
        else if (timeer == 0)
            CheckWinner ();
    }

    void CheckWinner()
    {
        if(P1Health > P2Health)
        {
            Debug.Log("P1Wins");
            playerOneWins = true;
            winText = 0;
            DisplayWinner();
        } else if (P1Health < P2Health)
        {
            Debug.Log("P2Wins");
            playerTwoWins = false;
            winText = 1;
            DisplayWinner();
        } else if (P1Health == P2Health)
        {
            tie = true;
            winText = 2;
            DisplayWinner();
        }
    }

    void DisplayWinner()
    {
        ended = true;
        winTexts[winText].SetActive(true);
        endCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void FIGHTEXCLAMATIONPOINT()
    {
        Time.timeScale = 1;
        startCanvas.SetActive(false);
        started = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
