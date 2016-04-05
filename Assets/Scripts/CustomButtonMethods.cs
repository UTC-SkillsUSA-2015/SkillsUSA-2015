using UnityEngine;
using System.Collections;

public class CustomButtonMethods : MonoBehaviour {

    [SerializeField]
    GameObject[] menus;

    [SerializeField]
    GameObject[] selectorManagers;

    [SerializeField]
    MenuManagment menuManag;

    [SerializeField]
    GameObject volumeControl;

    [SerializeField]
    Volume imSelec;

    [SerializeField]
    GameObject manag;

    [SerializeField]
    GameObject selectore;

    int whichMenu = 0;

    void Start()
    {
        changeMenu();
    }

	public void Options()
    {
        whichMenu = 1;
        menuManag.SelectedOne = 0;
        changeMenu();
    }

    public void ReturnToMenu()
    {
        whichMenu = 0;
        changeMenu();
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

#if UNITY_STANDALONE_WIN
        Application.Quit();
#endif
    }

    public void Blank()
    {
        UnityEngine.Debug.Log("Im Empty Inside");
    }

    void changeMenu()
    {
        foreach(GameObject menu in menus)
        {
            menu.SetActive(false);
        }

        foreach(GameObject managers in selectorManagers)
        {
            managers.SetActive(false);
        }

        menus[whichMenu].SetActive(true);
        selectorManagers[whichMenu].SetActive(true);
    }

    void deactivateManager()
    {
        manag.SetActive(false);
        selectore.SetActive(false);
    }

    void reactivateManager()
    {
        manag.SetActive(true);
        selectore.SetActive(true);
    }

    public void SelectVolume()
    {
        volumeControl.SetActive (true);
        imSelec.imSelected = true;
        deactivateManager();
    }

    public void DeselectVolume()
    {
        volumeControl.SetActive(false);
        imSelec.imSelected = false;
        reactivateManager();
    }
}
