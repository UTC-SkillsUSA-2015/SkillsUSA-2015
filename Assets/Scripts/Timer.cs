using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    [SerializeField]
    float maxTime;

    float timeInSeconds;

    [SerializeField]
    float fseconds;

    [SerializeField]
    float fminutes;

    int iSeconds;

    int iMinutes;

    Text _hudTime;

    [SerializeField]
    GameObject timerText;

    [SerializeField]
    bool testingMode;

    void Start()
    {
        timeInSeconds = maxTime;
        _hudTime = timerText.GetComponent<Text>();
    }

    void Update()
    {
        if (testingMode == false)
        {
            timeInSeconds -= Time.deltaTime;
            iSeconds = Mathf.FloorToInt(fseconds);
            iMinutes = Mathf.FloorToInt(fminutes);

            if (fseconds <= 0)
            {
                fseconds = 59;
                if (fminutes >= 1)
                {
                    fminutes--;
                }
                else
                {
                    fminutes = 0;
                    fseconds = 0;
                    _hudTime.text = ("0");
                }
            }
            //else
            //{
            //    fseconds -= Time.deltaTime;
            //    if (iSeconds > 10)
            //    {
            //        _hudTime.text = iMinutes + ":" + iSeconds;
            //    }
            //    else if (iSeconds < 10)
            //    {
            //        _hudTime.text = iMinutes + ":0" + iSeconds;
            //    }
            //}

            else
            {
                fseconds -= Time.deltaTime;
                if (iSeconds > 10)
                {
                    _hudTime.text = iSeconds.ToString();
                }
                else if (iSeconds < 10)
                {
                    _hudTime.text = iSeconds.ToString();
                }
            }

            if (iSeconds == 0 && iMinutes == 0)
            {
                Debug.Log("TimesUp");
            }
        }
    }
}
