using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderAssign : MonoBehaviour {

    public Text sliderValue;
    public Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (slider.maxValue>0)
        {
            sliderValue.text = (Mathf.RoundToInt(slider.value) + " assigned");
        }
        else if (slider.maxValue <= 0)
        {
            sliderValue.text = ("None available to assign");
        }
        
	}
}
