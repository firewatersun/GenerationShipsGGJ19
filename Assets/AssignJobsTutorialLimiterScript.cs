using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignJobsTutorialLimiterScript : MonoBehaviour {
    public Button foodButton;
    public Button airButton;
    public Button fuelButton;
    public Button securityButton;

    public TutorialScript tutorialScript;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void OnEnable () {
        if (tutorialScript.nowTrainingRed == true && tutorialScript.nowTrainingGreen == false && tutorialScript.nowTrainingBlue == false)
        {
            print("turningoffbuttonsforRed");
            foodButton.gameObject.SetActive(false);
            airButton.gameObject.SetActive(false);
            fuelButton.gameObject.SetActive(false);
            securityButton.gameObject.SetActive(true);
        }

        if (tutorialScript.nowTrainingGreen == true && tutorialScript.nowTrainingBlue == false)
        {
            securityButton.gameObject.SetActive(false);
            foodButton.gameObject.SetActive(true);
            airButton.gameObject.SetActive(true);
            fuelButton.gameObject.SetActive(true);
        }

        if (tutorialScript.nowTrainingBlue == true)
        {
            securityButton.gameObject.SetActive(true);
            foodButton.gameObject.SetActive(false);
            airButton.gameObject.SetActive(true);
            fuelButton.gameObject.SetActive(true);
        }
    }
}
