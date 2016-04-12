using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    [SerializeField]
    WinConditions startCheck;

    [SerializeField]
    GameObject pauseMenu;

    bool paused = false;

    [SerializeField]
    Fighter[] fighters;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (startCheck.started)
        {
            pauseMenu.SetActive(paused);
            if (paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

            if (Input.GetButtonDown("StartButton"))
            {
                paused = !paused;
            }

            foreach (Fighter fighter in fighters)
            {
                fighter.enabled = !paused;
            }
        } else
        {
            foreach(Fighter fighter in fighters)
            {
                fighter.enabled = false;
            }
        }
    }

    public void Unpause()
    {
        if (startCheck.started)
        {
            paused = false;
        }
    }
}
