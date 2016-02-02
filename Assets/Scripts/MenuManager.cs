using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    int whichMenu = 0;

    [SerializeField]
    GameObject[] menus;

    void Start()
    {
        ChangeMenu();
    }

	public void PvPMode()
    {
        Application.LoadLevel(2);
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(0);
    }

    public void TrainingMode()
    {
        Application.LoadLevel(1);
    }

    public void OptionsMenu()
    {
        whichMenu = 1;
        ChangeMenu();
    }

    public void CreditsMenu()
    {
        whichMenu = 2;
        ChangeMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        whichMenu = 0;
        ChangeMenu();
    }


    void ChangeMenu()
    {
        StartCoroutine("switchMenu");
    }

    IEnumerator switchMenu()
    {
        yield return new WaitForSeconds(0.001f);

        for (int i = 0; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
        }

        menus[whichMenu].SetActive(true);
        StopCoroutine("switchMenu");
    }
}
