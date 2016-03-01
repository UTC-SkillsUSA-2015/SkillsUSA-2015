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

    selectionMode whichPlayerSelecting;

    [SerializeField]
    GameObject[] characters;

    GameObject pOneSpawnPoint;
    GameObject pTwoSpawnPoint;

    public int pOneSelection;
    public int pTwoSelection;

    bool spawnPlayers = true;

    [SerializeField]
    Button pOnereselect;

    [SerializeField]
    Button startMatch;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
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
        if (SceneManager.GetActiveScene().name == "Character Select")
        {
            if (whichPlayerSelecting != selectionMode.READYTOGO)
            {
                startMatch.interactable = false;
                pOnereselect.interactable = false;
            }
            else
            {
                startMatch.interactable = true;
                pOnereselect.interactable = true;
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

    public void CCSelect()
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

    public void AASelect()
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
