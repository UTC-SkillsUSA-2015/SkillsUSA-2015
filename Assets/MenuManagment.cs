using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuManagment : MonoBehaviour {

    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    CustomButton[] buttonCall;

    [SerializeField]
    Image selector;

    [SerializeField]
    float lerpTime;

    float currentLerpTime;

    public int SelectedOne = 0;

    void Start()
    {
        selector.transform.position = buttons[SelectedOne].transform.position;
    }

    void Update()
    {
        currentLerpTime += Time.deltaTime;
        if(currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SelectedOne++;
            currentLerpTime = 0;
            CheckSelect();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SelectedOne--;
            currentLerpTime = 0;
            CheckSelect();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            buttonCall[SelectedOne].selectButton();
        }

        float perc = currentLerpTime / lerpTime;
        selector.transform.position = Vector3.Lerp(selector.transform.position, buttons[SelectedOne].transform.position, perc);
    }

    void CheckSelect()
    {
        if (SelectedOne > buttons.Length - 1)
        {
            SelectedOne = 0;
        }
        else if (SelectedOne < 0)
        {
            SelectedOne = buttons.Length - 1;
        }
    }
}
