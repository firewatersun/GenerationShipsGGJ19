using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {
    //public GameObject FoodCanvas;
    //public GameObject FuelCanvas;
    //public GameObject AirCanvas;
    //public GameObject SecurityCanvas;

    public bool nowTrainingRed;
    public bool nowTrainingGreen;
    public bool nowTrainingBlue;
    float startTime;
    //public float waitTime;

    public GameObject[] assignJobsCanvases;

    public Button trainingRedText;
    public Button trainingGreenText;
    public Button trainingBlueText;

    public Button assignJobs;


    public Button assignRedsles;
    public Button assignedRedsles;
    public Button assignGreenies;
    public Button assignedGreenies;
    public Button assignBluehoos;
    public Button assignedBluehoos;

    public FleetManager fleetMgmtScript;
    public TimelineManager timelineScript;

    // Use this for initialization
    void Start () {
        fleetMgmtScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<FleetManager>();
        nowTrainingRed = false;
        nowTrainingBlue = false;
        nowTrainingGreen = false;
        timelineScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<TimelineManager>();
    }
	
	// Update is called once per frame
	void Update () {
        assignJobsCanvases = GameObject.FindGameObjectsWithTag("gamePausing");

        if (fleetMgmtScript.fleetSystemAir <=0 || fleetMgmtScript.fleetSystemFood <= 0 || fleetMgmtScript.fleetSystemFuel <= 0 || timelineScript.gameEnd == true)
        {
            print("reloadingFromTutorial");
            SceneManager.LoadScene("Intro and Tutorial");
        }

        if (nowTrainingRed == true && nowTrainingGreen ==false)
        {

            print("nowTrainingRedUpdate");


            foreach (GameObject canvas in assignJobsCanvases)
            {
                canvas.GetComponent<PopulationManager>().R.gameObject.SetActive(true);
                canvas.GetComponent<PopulationManager>().G.gameObject.SetActive(false);
                canvas.GetComponent<PopulationManager>().B.gameObject.SetActive(false);
            }

        }

        if (nowTrainingGreen == true && nowTrainingBlue ==false)
        {
            print("nowTrainingGreenUpdate");
            
            foreach (GameObject canvas in assignJobsCanvases)
            {
                canvas.GetComponent<PopulationManager>().R.gameObject.SetActive(false);
                canvas.GetComponent<PopulationManager>().G.gameObject.SetActive(true);
                canvas.GetComponent<PopulationManager>().B.gameObject.SetActive(false);
            }

        }



        if (nowTrainingBlue == true)
        {
            print("nowTrainingBlueUpdate");

            foreach (GameObject canvas in assignJobsCanvases)
            {
                canvas.GetComponent<PopulationManager>().R.gameObject.SetActive(false);
                canvas.GetComponent<PopulationManager>().G.gameObject.SetActive(false);
                canvas.GetComponent<PopulationManager>().B.gameObject.SetActive(true);
            }

        }

        if (fleetMgmtScript.joblessR <= 0 && nowTrainingGreen == false)
        {
            
            assignJobs.gameObject.SetActive(false);
            assignRedsles.gameObject.SetActive(false);
            assignedRedsles.gameObject.SetActive(true);
        }

        if (fleetMgmtScript.joblessG <= 0 && nowTrainingBlue == false)
        {
            
            assignJobs.gameObject.SetActive(false);
            assignGreenies.gameObject.SetActive(false);
            assignedGreenies.gameObject.SetActive(true);
        }

        if (fleetMgmtScript.joblessB <= 0)
        {

            assignJobs.gameObject.SetActive(false);
            assignBluehoos.gameObject.SetActive(false);
            assignedBluehoos.gameObject.SetActive(true);
        }

    }

    public void TrainingRed() { 
        nowTrainingRed = true;
    }

    public void TrainingGreen()
    {
        print("nowTrainingGreen");
        nowTrainingGreen = true;
        assignJobs.gameObject.SetActive(true);
        assignedRedsles.gameObject.SetActive(false);
        trainingRedText.gameObject.SetActive(false);
        trainingGreenText.gameObject.SetActive(true);
        
    }

    public void TrainingBlue()
    {
        print("nowTrainingBlue");
        nowTrainingBlue = true;
        assignJobs.gameObject.SetActive(true);
        assignedGreenies.gameObject.SetActive(false);
        trainingGreenText.gameObject.SetActive(false);
        trainingBlueText.gameObject.SetActive(true);
        
    }
}
