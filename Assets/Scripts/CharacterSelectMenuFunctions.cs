using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelectMenuFunctions : MonoBehaviour {

    [SerializeField]
    float scaleObject;

    [SerializeField]
    Image menuObject;

    //[SerializeField]
    //GameObject characterIcon;

    [SerializeField]
    GameObject moreInfo;

    [SerializeField]
    Image button;

    [SerializeField]
    float extendSpeed;

    bool Extend = false;

    Vector2 resetExtendMenu;

    Vector2 extendMenuRectTrans;

    Vector3 resetExtendPos;

    Vector3 ExtendPos;
    
    Vector3 resetScale;

  

    void Start()
    {
        resetScale = new Vector3(0.54f, 0.54f, 0.54f);
        resetChange();
        resetExtendMenu = menuObject.rectTransform.sizeDelta;
        resetExtendPos = menuObject.rectTransform.anchoredPosition;
        ExtendPos = new Vector2(170, 0);
    }

    void Update()
    {
        if (Extend)
        {
            menuObject.rectTransform.sizeDelta = Vector2.Lerp(menuObject.rectTransform.sizeDelta, menuObject.rectTransform.sizeDelta = new Vector2(370, 36.6f), Time.deltaTime * extendSpeed);
            menuObject.rectTransform.anchoredPosition = Vector2.Lerp(menuObject.rectTransform.anchoredPosition, ExtendPos, Time.deltaTime * extendSpeed);
            moreInfo.SetActive(true);
        }  else
        {
            menuObject.rectTransform.sizeDelta = resetExtendMenu;
            menuObject.rectTransform.anchoredPosition = resetExtendPos;
            moreInfo.SetActive(false);
        }
    }

    //void OnEnable()
    //{
    //    resetChange();
    //}

    public void mouseOverChange()
    {
        transform.localScale += new Vector3(scaleObject, scaleObject, 0f);
        Extend = true;
    }

    public void resetChange()
    {
        transform.localScale = resetScale;
        Extend = false;
    }
}

