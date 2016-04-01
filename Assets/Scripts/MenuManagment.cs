using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuManagment : MonoBehaviour {

    public enum Dpad {None, Right, Left, Up, Down}
    private bool flag = true;
    private Dpad control = Dpad.None;

    [SerializeField]
    GameObject[] buttons;

    [SerializeField]
    CustomButton[] buttonCall;

    [SerializeField]
    Image selector;

    [SerializeField]
    float lerpTime;

    float currentLerpTime;

    float holdTime = 0.4f;
    float held = 0;

    public bool pressed = false;

    public int SelectedOne = 0;

    void Start()
    {
        selector.transform.position = buttons[SelectedOne].transform.position;
    }

    void Update()
    {
        //float debug = Input.GetAxis("LeftJoyY");
        //Debug.Log (debug);
        currentLerpTime += Time.deltaTime;
        bool keyPressed = false;
        pressed = keyPressed;

        if (currentLerpTime > lerpTime)
        {
            currentLerpTime = lerpTime;
        }

        PadControll();

        if (Input.GetKeyDown(KeyCode.S) || held >= holdTime)
        {
            SelectedOne++;
            currentLerpTime = 0;
            held = 0;
            CheckSelect();
        }
        else
        {
            keyPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.W) || held <= -holdTime)
        {
            SelectedOne--;
            currentLerpTime = 0;
            held = 0;
            CheckSelect();
        }
        else
        {
            keyPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("AP1"))
        {
            buttonCall[SelectedOne].selectButton();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetAxis("DPadYP1") == 1f || Input.GetAxis("LeftJoyYP1") == 1f)
        {
            held = held - Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetAxis("DPadYP1") == -1f || Input.GetAxis("LeftJoyYP1") == -1f)
        {
            held = held + Time.deltaTime;
        }
        else
        {
            held = 0;
        }

        float perc = currentLerpTime / lerpTime;
        selector.transform.position = Vector3.Lerp(selector.transform.position, buttons[SelectedOne].transform.position, perc);
    }

    void PadControll()
    {
        if(Input.GetAxis("DPadYP1") == 0.0 || Input.GetAxis("LeftJoyYP1") == 0.0)
        {
            control = Dpad.None;
            flag = true;
        }

        if (Input.GetAxis("DPadYP1") == 1f && flag || Input.GetAxis("LeftJoyYP1") == 1f && flag)
        {
            StartCoroutine("DpadControl", Dpad.Up);
        }
        if (Input.GetAxis("DPadYP1") == -1f && flag || Input.GetAxis("LeftJoyYP1") == -1f && flag)
        {
            StartCoroutine("DpadControl", Dpad.Down);

        }
    }

    IEnumerator DpadControl(Dpad value)
    {
        flag = false;
        yield return new WaitForSeconds(0.15f); // delay it as you wish 
        if (value == Dpad.Up) DPadUp();  //** go up
        if (value == Dpad.Down) DPadDown(); //** go down

        StopCoroutine("DpadControl");
    }

    void DPadUp()
    {
        SelectedOne--;
        currentLerpTime = 0;
        held = 0;
        CheckSelect();
    }

    void DPadDown()
    {
        SelectedOne++;
        currentLerpTime = 0;
        held = 0;
        CheckSelect();
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
