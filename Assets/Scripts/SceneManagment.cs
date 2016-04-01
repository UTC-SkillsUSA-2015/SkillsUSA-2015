using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour {

    //static SceneManagment Instance;

    //void Start()
    //{
    //    if(Instance != null)
    //    {
    //        GameObject.Destroy(gameObject);
    //    } else
    //    {
    //        GameObject.DontDestroyOnLoad(gameObject);
    //        Instance = this;
    //    }
    //}

    void Update()
    {
        if (Input.GetButtonDown("BP1") || Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "CharacterSelect2.0")
            {
                SceneManager.LoadScene("MainMenu2.0");
            }
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu2.0");
    }

    public void LoadCharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect2.0");
    }

    public void LoadFightScene()
    {
        SceneManager.LoadScene("FightScene");
    }
}
