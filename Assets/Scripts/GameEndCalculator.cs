using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndCalculator : MonoBehaviour {
    public float refusedR;
    public float refusedG;
    public float refusedB;

    public float assignedSecurityR;
    public float assignedAirG;
    public float assignedFoodG;
    public float assignedFuelG;
    public float unassignedB;
   

    public float biasPercentR;
    public float biasPercentG;
    public float biasPercentB;

    public float totalRefused;

    public FleetManager fleetManScript;
    // Use this for initialization
    void Start () {
        fleetManScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<FleetManager>();
    }
	
	// Update is called once per frame
	void Update () {
        unassignedB = fleetManScript.joblessB;
        biasPercentR = fleetManScript.securityJobR / (fleetManScript.securityJobR + fleetManScript.securityJobG + fleetManScript.securityJobG)*100;
        float productionJobsG = fleetManScript.airJobG + fleetManScript.fuelJobG + fleetManScript.foodJobG;
        biasPercentG = productionJobsG / fleetManScript.totalFleetPopG * 100;
        totalRefused = (refusedR + refusedB + refusedG);
    }
}
