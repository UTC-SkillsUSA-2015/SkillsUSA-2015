using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum selectionMode
{
    PONESELECTION,
    PTWOSELECTION,
    READYTOGO
}

public class CharacterSelector : MonoBehaviour {

    [SerializeField]
    selectionMode whichPlayerSelecting;

    [SerializeField]
    GameObject[] characters;

    GameObject pOneSpawnPoint;
    GameObject pTwoSpawnPoint;

    public int pOneSelection;
    public int pTwoSelection;

    bool spawnPlayers = true;

    [SerializeField]
    SceneManagment scene;

    [SerializeField]
    GameObject selector;

    [SerializeField]
    GameObject startMatch;

    [SerializeField]
    MenuManagment menu;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        whichPlayerSelecting = selectionMode.PONESELECTION;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenuUI")
        {
            Destroy(this.gameObject);
        }
            if (SceneManager.GetActiveScene().name == "UITESTSCENE")
        {
            if (spawnPlayers)
            {
                pOneSpawnPoint = GameObject.FindGameObjectWithTag("ponespawn");
                pTwoSpawnPoint = GameObject.FindGameObjectWithTag("ptwospawn");
                Instantiate(characters[pOneSelection], pOneSpawnPoint.transform.position, transform.rotation);
                Instantiate(characters[pTwoSelection], pTwoSpawnPoint.transform.position, transform.rotation);
                spawnPlayers = false;
            }       
        }

        if (SceneManager.GetActiveScene().name == "CharacterSelect2.0")
        {
            if (whichPlayerSelecting != selectionMode.READYTOGO)
            {
                startMatch.SetActive (false);
                selector.SetActive(true);
            }
            else
            {
                startMatch.SetActive (true);
                selector.SetActive(false);
                menu.SelectedOne = 0;
                if (Input.GetButtonDown("AP1"))
                {
                    scene.LoadFightScene();
                }
                if (Input.GetButtonDown("XP1"))
                {
                    pOneSelect();
                }
            }
        }
    }

    public void SmileySelect()
    {
        if(whichPlayerSelecting == selectionMode.PONESELECTION)
        {
            pOneSelection = 0;
            whichPlayerSelecting = selectionMode.PTWOSELECTION;
        }
        else if (whichPlayerSelecting == selectionMode.PTWOSELECTION)
        {
            pTwoSelection = 0;
            whichPlayerSelecting = selectionMode.READYTOGO;
        }
    }

    public void BubblesSelect()
    {
        if (whichPlayerSelecting == selectionMode.PONESELECTION)
        {
            pOneSelection = 1;
            whichPlayerSelecting = selectionMode.PTWOSELECTION;
        }
        else if (whichPlayerSelecting == selectionMode.PTWOSELECTION)
        {
            pTwoSelection = 1;
            whichPlayerSelecting = selectionMode.READYTOGO;
        }
    }

    public void TyreseSelect()
    {
        if (whichPlayerSelecting == selectionMode.PONESELECTION)
        {
            pOneSelection = 2;
            whichPlayerSelecting = selectionMode.PTWOSELECTION;
        }
        else if (whichPlayerSelecting == selectionMode.PTWOSELECTION)
        {
            pTwoSelection = 2;
            whichPlayerSelecting = selectionMode.READYTOGO;
        }
    }

    public void pOneSelect()
    {
        whichPlayerSelecting = selectionMode.PONESELECTION;
    }
}
