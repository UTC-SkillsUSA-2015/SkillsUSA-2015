using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    [SerializeField]
    Slider self;

    [SerializeField]
    Text volumeValue;

    public bool imSelected = false;

    public float sliderValue;

    [SerializeField]
    CustomButtonMethods deselect;

	void Start () {
        sliderValue = AudioListener.volume;
	}
	
	void Update () {
        AudioListener.volume = sliderValue;

        volumeValue.text = Mathf.Round((sliderValue)*100).ToString();

        self.value = sliderValue;

        if (sliderValue > 1)
            sliderValue = 1;

        if (sliderValue < 0)
            sliderValue = 0;

        if (imSelected)
        {
            if (Input.GetAxis("DPadXP1") > 0 && sliderValue < 1)
            {
                sliderValue += 0.01f;
            }
            else if (Input.GetAxis("DPadXP1") < 0 && sliderValue > 0)
            {
                sliderValue -= 0.01f;
            }

            if (Input.GetButtonDown("AP1"))
            {
                deselect.DeselectVolume();
            }
        }
    }
}
