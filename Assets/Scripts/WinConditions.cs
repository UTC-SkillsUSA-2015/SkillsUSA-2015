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

    [SerializeField]
    GameObject fight;

    [SerializeField]
    GameObject P1Ready;

    [SerializeField]
    GameObject checks;

    bool isP1Ready = false;

    [SerializeField]
    GameObject P2Ready;

    bool isP2Ready = false;

    bool flag = false;

    int winText = 0;

    float P1Health;
    float P2Health;

    [SerializeField]
    Timer timer;

    float timerFloat;

    public float enumeratorTimer;

    bool playerOneWins = false;
    bool playerTwoWins = false;
    bool tie = false;
    public bool started { get; private set; }
    public bool ended { get; private set; }

	[SerializeField]
	PauseGame pause;

	void Start () {
        fight.SetActive(false);
        P1Ready.SetActive(false);
        P2Ready.SetActive(false);
        Time.timeScale = 0;
        endCanvas.SetActive(false);
        startCanvas.SetActive(true);
	}
	
	void Update () {
        timerFloat = timer.fseconds;
        P1Health = (float)P1Script.CurrentHealth;
        P2Health = (float)P2Script.CurrentHealth;

        if (!started)
        {
            if (Input.GetButtonDown("AP1"))
            {
                isP1Ready = true;
            }

            if (Input.GetButtonDown("AP2"))
            {
                isP2Ready = true;
            }

            if (isP1Ready)
            {
                P1Ready.SetActive(true);
            }

            if (isP2Ready)
            {
                P2Ready.SetActive(true);
            }

            if (isP1Ready && isP2Ready && !flag)
            {
                StartCoroutine("Hide");
                flag = true;
            }

        }

        if (P1Health == 0 || P2Health == 0) {
            CheckWinner ();
        }
        else if (timerFloat == 0)
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
		pause.gameOver = true;	
		Time.timeScale = 0;
        ended = true;
        winTexts[winText].SetActive(true);
        endCanvas.SetActive(true);
    }

    IEnumerator Hide()
    {
        enumeratorTimer = 0.2f;
        while (true)
        {
            float pauseEndTime = Time.realtimeSinceStartup + 0.3f;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            enumeratorTimer -= 0.1f;
            if (enumeratorTimer <= 0)
            {
                fight.SetActive(true);
                checks.SetActive(false);
                StopCoroutine("Hide");
                StartCoroutine("Counter");
            }
        }
    }

    IEnumerator Counter()
    {
        enumeratorTimer = 1;
        while (true)
        {
            float pauseEndTime = Time.realtimeSinceStartup + 1f;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            enumeratorTimer -= 1;
            if (enumeratorTimer <= 0)
            {
                FIGHTEXCLAMATIONPOINT();
                StopCoroutine("Counter");
            }
        }
    }

    void FIGHTEXCLAMATIONPOINT()
    {
        Time.timeScale = 1;
        startCanvas.SetActive(false);
        started = true;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public void quit()
	{
		SceneManager.LoadScene("MainMenu2.0");
	}
}
