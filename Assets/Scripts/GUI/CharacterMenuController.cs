using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterMenuController : MonoBehaviour {

    int whichCharacter = 0;

    [SerializeField]
    GameObject[] characterMenus;

    [SerializeField]
    Image CharacterInfo;

    [SerializeField]
    float extendSpeed;

    bool ExtendMenu = false;

    Vector2 resetExtendMenu;

    Vector2 extendMenuRectTrans;

    Vector3 resetExtendPos;

    Vector3 ExtendPos;

    void Start()
    {
        ChangeMenu();
        //resetExtendMenu = CharacterInfo.rectTransform.right;
        resetExtendPos = CharacterInfo.rectTransform.anchoredPosition;
        ExtendPos = new Vector2(0, 0);
    }

    void Update()
    {
        if(whichCharacter != 0)
        {
            ExtendMenu = true;
        } else
        {
            ExtendMenu = false;
        }


        if (ExtendMenu)
        {
            CharacterInfo.rectTransform.sizeDelta = Vector2.Lerp(CharacterInfo.rectTransform.sizeDelta, CharacterInfo.rectTransform.sizeDelta = new Vector2(0, 0), Time.deltaTime * extendSpeed);
            CharacterInfo.rectTransform.anchoredPosition = Vector2.Lerp(CharacterInfo.rectTransform.anchoredPosition, ExtendPos, Time.deltaTime * extendSpeed);
        } else if (!ExtendMenu)
        {
            CharacterInfo.rectTransform.sizeDelta = Vector2.Lerp(CharacterInfo.rectTransform.sizeDelta, CharacterInfo.rectTransform.sizeDelta = new Vector2(-1920, 0), Time.deltaTime * extendSpeed);
            CharacterInfo.rectTransform.anchoredPosition = Vector2.Lerp(CharacterInfo.rectTransform.anchoredPosition, resetExtendPos, Time.deltaTime * extendSpeed);
        }
    }



    bool OpenCharacterMenu = false;

    public void SmileyMenu()
    {
        whichCharacter = 1;
        ChangeMenu();
    }

    public void CCMenu()
    {
        whichCharacter = 2;
        ChangeMenu();
    }

    public void AAMenu()
    {
        whichCharacter = 3;
        ChangeMenu();
    }

    public void CharacterSelect()
    {
        whichCharacter = 0;
        ChangeMenu();
    }

    void ChangeMenu()
    {
        StartCoroutine("switchMenu");
    }

    IEnumerator switchMenu()
    {
        yield return new WaitForSeconds(0.001f);

        for (int i = 0; i < characterMenus.Length; i++)
        {
            characterMenus[i].SetActive(false);
        }

        characterMenus[whichCharacter].SetActive(true);
        StopCoroutine("switchMenu");
    }
}
