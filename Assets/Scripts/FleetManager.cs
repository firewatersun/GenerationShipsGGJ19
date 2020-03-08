using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FleetManager : MonoBehaviour {
    //modifiers
    public int airJobMultiplier;
    public int foodJobMultiplier;
    public int fuelJobMultiplier;
    public int airSupportsPop;
    public int foodSupportsPop;
    public int fuelSupportsPop;
    //fleetsystems
    public int fleetSystemFood;
    public int fleetSystemAir;
    public int fleetSystemFuel;
    //fleetJobs
    public int foodJob;
    public int airJob;
    public int fuelJob;
    public int jobless;
    public int securityJob;
    public int securityJobR;
    public int securityJobG;
    public int securityJobB;
    public int joblessR;
    public int joblessG;
    public int joblessB;
    public int airJobR;
    public int airJobG;
    public int airJobB;
    public int foodJobR;
    public int foodJobG;
    public int foodJobB;
    public int fuelJobR;
    public int fuelJobG;
    public int fuelJobB;
    //fleet event stats
    //fleet population stats
    public int totalFleetPopR;
    public int totalFleetPopG;
    public int totalFleetPopB;
    public int fleetMorale;
    public int fleetTotalPopulation;
    public int inputFleetToleranceHere;
    float riotLikelihood;
    //time info
    float currentTime;
    float checkTime;
    public float fleetUpdateInterval;
    public GameObject[] fleetShips;
    //riot GameObject
    public GameObject riotEvent;
    //UI text
    public Text PopDisplayR;
    public Text PopDisplayG;
    public Text PopDisplayB;
    public Text fleetAir;
    public Text fleetFood;
    public Text fleetFuel;
    //
    public Text fleetAirGen;
    public Text fleetFoodGen;
    public Text fleetFuelGen;
    public Text fleetSec;
    public RandomEventManager randomEventManagerScript;
    public Button assignJobs;
    public Button cannotAssignJobs;

    public bool gameOver;
    public bool timelinePauseGame;
    public bool assigningJobs;
    // Use this for initialization
    void Start () {
        gameOver = false;
        checkTime = Time.time;
        //FleetSystemsUpdate();
    }
	
	// Update is called once per frame
	void Update () {

        joblessR = totalFleetPopR - airJobR - foodJobR - fuelJobR - securityJobR;
        joblessG = totalFleetPopG - airJobG - foodJobG - fuelJobG - securityJobG;
        joblessB = totalFleetPopB - airJobB - foodJobB - fuelJobB - securityJobB;
        jobless = joblessR + joblessG + joblessG;
        securityJob = securityJobR + securityJobG + securityJobB;
        airJob = airJobR + airJobB + airJobG;
        foodJob = foodJobR + foodJobG + foodJobB;
        fuelJob = fuelJobR + fuelJobG + fuelJobB;
        if (joblessR<0)
        {
            joblessR = 0;
        }
        if (joblessG < 0)
        {
            joblessG = 0;
        }
        if (joblessB < 0)
        {
            joblessB = 0;
        }



        if (joblessR<=0 && joblessG<=0 && joblessB<=0)
        {
            //assignJobs.gameObject.SetActive(false);
            cannotAssignJobs.gameObject.SetActive(true);
        }
        else if (joblessR > 0 || joblessG > 0 || joblessB > 0)
        {
            cannotAssignJobs.gameObject.SetActive(false);
            //assignJobs.gameObject.SetActive(true);
        }
        //update UI
        fleetAirGen.text = ("AIR GENERATION RATE: " + airJob*airJobMultiplier*airSupportsPop);
        fleetFoodGen.text = ("FOOD GENERATION RATE: " + foodJob*foodJobMultiplier*foodSupportsPop);
        fleetFuelGen.text = ("FUEL GENERATION RATE: " + fuelJob*fuelJobMultiplier*fuelSupportsPop);
        fleetSec.text = ("FLEET SECURITY: " + securityJob);

        if (securityJob > 1)
        {
            securityJob = 1;
        }
        if (airJob > 1)
        {
            airJob = 1;
        }
        if (foodJob > 1)
        {
            foodJob = 1;
        }
        if (fuelJob > 1)
        {
            fuelJob = 1;
        }

        //text update
        PopDisplayR.text = ("Redsles pop: " + totalFleetPopR + " with " + joblessR + " jobless");
        PopDisplayG.text = ("Greenies pop: " + totalFleetPopG + " with " + joblessG + " jobless");
        PopDisplayB.text = ("Bluehoos pop: " + totalFleetPopB + " with " + joblessB + " jobless");

        fleetAir.text = ("AIR: " + fleetSystemAir);
        fleetFood.text = ("FOOD: " + fleetSystemFood);
        fleetFuel.text = ("FUEL: " + fleetSystemFuel);

        currentTime = Time.time;
        if (currentTime-checkTime >= fleetUpdateInterval)
        {
            FleetSystemsUpdate();
        }
	}

    void FleetSystemsUpdate() {
        if (gameOver == false && timelinePauseGame == false)
        {
            checkTime = Time.time;
            fleetShips = GameObject.FindGameObjectsWithTag("fleetship");
            fleetTotalPopulation = totalFleetPopR + totalFleetPopG + totalFleetPopB;
            //print(fleetTotalPopulation);
            //update with ship Generation stats
            //foreach (GameObject fleetship in fleetShips)
            //{
            //    fleetSystemFood = fleetSystemFood + fleetship.GetComponent<ShipStartStats>().foodGeneration;
            //    fleetSystemAir = fleetSystemAir + fleetship.GetComponent<ShipStartStats>().airGeneration;
            //    fleetSystemFuel = fleetSystemFuel + fleetship.GetComponent<ShipStartStats>().fuelGeneration;
            //}
            //update with job Generation stats
            fleetSystemAir = fleetSystemAir + airJob*airJobMultiplier - Mathf.RoundToInt(fleetTotalPopulation / airSupportsPop);
            fleetSystemFood = fleetSystemFood + foodJob*foodJobMultiplier - Mathf.RoundToInt(fleetTotalPopulation / foodSupportsPop);
            fleetSystemFuel = fleetSystemFuel + fuelJob*fuelJobMultiplier - Mathf.RoundToInt(fleetTotalPopulation / fuelSupportsPop);

            //update Fleet Morale

            fleetMorale = (fleetSystemFood / (fleetTotalPopulation)) + (fleetSystemFuel / fleetTotalPopulation) + (fleetSystemAir / fleetTotalPopulation) - jobless;
            print("fleet morale" + fleetMorale);

            if (fleetMorale >= inputFleetToleranceHere && fleetMorale > inputFleetToleranceHere / 2)
            {
                riotLikelihood = Random.Range(0, 100);
            }
            else if (fleetMorale <= inputFleetToleranceHere / 2 && fleetMorale > 0)
            {
                riotLikelihood = Random.Range(0, 25);
            }
            else if (fleetMorale <= 0 && fleetMorale > -inputFleetToleranceHere / 2)
            {
                riotLikelihood = Random.Range(0, 10);
            }
            else if (fleetMorale <= -inputFleetToleranceHere / 2)
            {
                riotLikelihood = Random.Range(0, 2);
            }

            if (riotLikelihood <= 1 && randomEventManagerScript.eventHappening == false)
            {
                GameObject.Instantiate(riotEvent);
            }
        }
        


    }


    public void AssigningJobs()
    {

        assignJobs.gameObject.SetActive(false);
    }


    public void NotAssigningJobs()
    {
        assignJobs.gameObject.SetActive(true);
    }
}
