using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationManager : MonoBehaviour {
    public int totalPopulation;
    public int joblessR;
    public int joblessG;
    public int joblessB;
    public Slider R;
    public Slider G;
    public Slider B;
    public bool foodJobs;
    public bool airJobs;
    public bool fuelJobs;
    public bool securityJobs;
    public FleetManager fleetManScript;
    public GameEndCalculator gameEndCalculator;
    // Use this for initialization

    void OnEnable () {
        fleetManScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<FleetManager>();
        gameEndCalculator = GameObject.FindGameObjectWithTag("gameEndCalculator").GetComponent<GameEndCalculator>();

        joblessR = fleetManScript.joblessR;
        joblessG = fleetManScript.joblessG;
        joblessB = fleetManScript.joblessB;

        R.value = 0f;
        G.value = 0f;
        B.value = 0f;

        R.maxValue = joblessR;
        G.maxValue = joblessG;
        B.maxValue = joblessB;
    }
	
	// Update is called once per frame
	void Update () {
        joblessR = fleetManScript.joblessR;
        joblessG = fleetManScript.joblessG;
        joblessB = fleetManScript.joblessB;

        R.maxValue = joblessR;
        G.maxValue = joblessG;
        B.maxValue = joblessB;
    }

    public void AssignAllJobs() {
        if (foodJobs == true)
        {
            int RJobsAssigned = Mathf.RoundToInt(R.value);
            int GJobsAssigned = Mathf.RoundToInt(G.value);
            int BJobsAssigned = Mathf.RoundToInt(B.value);

            fleetManScript.foodJobR += RJobsAssigned;
            fleetManScript.foodJobG += GJobsAssigned;
            fleetManScript.foodJobB += BJobsAssigned;

            fleetManScript.joblessR -= RJobsAssigned;
            fleetManScript.joblessG -= GJobsAssigned;
            fleetManScript.joblessB -= BJobsAssigned;

            gameEndCalculator.assignedFoodG += GJobsAssigned;
        }

        if (securityJobs == true)
        {
            int RJobsAssigned = Mathf.RoundToInt(R.value);
            int GJobsAssigned = Mathf.RoundToInt(G.value);
            int BJobsAssigned = Mathf.RoundToInt(B.value);

            fleetManScript.securityJobR += RJobsAssigned;
            fleetManScript.securityJobG += GJobsAssigned;
            fleetManScript.securityJobB += BJobsAssigned;

            fleetManScript.joblessR -= RJobsAssigned;
            fleetManScript.joblessG -= GJobsAssigned;
            fleetManScript.joblessB -= BJobsAssigned;

            gameEndCalculator.assignedSecurityR += RJobsAssigned;
        }

        if (fuelJobs == true)
        {
            int RJobsAssigned = Mathf.RoundToInt(R.value);
            int GJobsAssigned = Mathf.RoundToInt(G.value);
            int BJobsAssigned = Mathf.RoundToInt(B.value);

            fleetManScript.fuelJobR += RJobsAssigned;
            fleetManScript.fuelJobG += GJobsAssigned;
            fleetManScript.fuelJobB += BJobsAssigned;

            fleetManScript.joblessR -= RJobsAssigned;
            fleetManScript.joblessG -= GJobsAssigned;
            fleetManScript.joblessB -= BJobsAssigned;
            gameEndCalculator.assignedFuelG += GJobsAssigned;
        }

        if (airJobs == true)
        {
            int RJobsAssigned = Mathf.RoundToInt(R.value);
            int GJobsAssigned = Mathf.RoundToInt(G.value);
            int BJobsAssigned = Mathf.RoundToInt(B.value);

            fleetManScript.airJobR += RJobsAssigned;
            fleetManScript.airJobG += GJobsAssigned;
            fleetManScript.airJobB += BJobsAssigned;

            fleetManScript.joblessR -= RJobsAssigned;
            fleetManScript.joblessG -= GJobsAssigned;
            fleetManScript.joblessB -= BJobsAssigned;

            gameEndCalculator.assignedAirG += GJobsAssigned;
        }
    }
}
