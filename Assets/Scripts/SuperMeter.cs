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
    byte powerLevel;

    [SerializeField]
    Color[] levelColors;

    [SerializeField]
    float fillSpeed = 1;

    public int Levels { get { return levelColors.Length - 1; } }

    void Start()
    {
        Debug.Log(fillAmount);
        ChangeColors();
        superFill.fillAmount = 0;
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
        
        if(powerLevel == Levels)
        {
            fillAmount = 0;
        }

        if (fillAmount >= 1)
        {
            fillAmount--;
            powerLevel = (byte)Mathf.Clamp(powerLevel + 1, 0, Levels);
            superFill.fillAmount = fillAmount;
            ChangeColors();
        }

        superFill.fillAmount += (fillAmount - superFill.fillAmount) / fillSpeed;
    }

    void ChangeColors()
    {
        superBack.color = levelColors[powerLevel];
        superFill.color = levelColors[powerLevel + 1];
    }

    bool UsePower(byte amount)
    {
        if (amount > powerLevel) return false;
            
        else
        {
            powerLevel -= amount;
            ChangeColors();
            return true;
        }
    }





}
