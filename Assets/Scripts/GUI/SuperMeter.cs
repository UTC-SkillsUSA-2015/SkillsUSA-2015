using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SuperMeter : MonoBehaviour {

    [SerializeField]
    Image superFill;

    [SerializeField]
    Image superBack;

    [SerializeField]
    float fillAmount;

    [SerializeField]
    byte kPowerLevel;

    [SerializeField]
    Color[] levelColors;

    [SerializeField]
    float fillSpeed = 1;

    [SerializeField]
    Text counterText;

    [SerializeField]
    byte startingPowerLevel;

    public int Levels { get { return levelColors.Length - 1; } }

    public byte PowerLevel
    {
        get
        {
            return kPowerLevel;
        }

        set
        {
            kPowerLevel = value;
            counterText.text = PowerLevel.ToString();
            ChangeColors();
        }
    }

    void Start()
    {
        //Debug.Log(fillAmount);
        ChangeColors();
        superFill.fillAmount = 0;
        PowerLevel = startingPowerLevel;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            fillAmount += 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            fillAmount += 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            fillAmount += 1f;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            if(!UsePower(1))Debug.Log("IT'S NO USE!");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (!UsePower(3)) Debug.Log("IT'S NO USE!");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {

            if (!UsePower(5)) Debug.Log("IT'S NO USE!");
        }
        
        if(PowerLevel == Levels)
        {
            fillAmount = 0;
        }

        if (fillAmount >= 1)
        {
            fillAmount--;
            PowerLevel = (byte)Mathf.Clamp(PowerLevel + 1, 0, Levels);
            superFill.fillAmount = fillAmount;
            //ChangeColors();
        }

        superFill.fillAmount += (fillAmount - superFill.fillAmount) / fillSpeed;
    }

    void ChangeColors()
    {
        superBack.color = levelColors[PowerLevel];
        superFill.color = levelColors[PowerLevel + 1];
   
    }

    bool UsePower(byte amount)
    {
        if (amount > PowerLevel) return false;
            
        else
        {
            PowerLevel -= amount;
            //ChangeColors();
            return true;
        }
    }





}
