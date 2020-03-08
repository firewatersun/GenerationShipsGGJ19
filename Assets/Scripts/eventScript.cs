using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eventScript : MonoBehaviour {
    public float eventLength;
    public Text countDown;
    float startTime;
    float timeLeft;
    //reduce food Stats
    public float reduceFoodBy;
    public float reduceAirBy;
    public float reduceFuelBy;
    //reduce populationStats;
    public float reducePopPercentBy;
    public string successString;
    public string failureString;
    public string eventNameString;
    public Text eventName;
    public Text eventEndDisplay;
    float destroyCalledTime;
    float pauseTime;
    //checks
    public float minSecurityLevel;
    public bool isThisPopulationThreatening;
    bool eventEnd;

    public bool timelinePauseGame;

    public FleetManager fleetManagerScript;
    public RandomEventManager randomEventManagerScript;

    // Use this for initialization
    void OnEnable () {
        minSecurityLevel = minSecurityLevel * 0.01f;
        eventName.text = (eventNameString);
        startTime = Time.time;
        fleetManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<FleetManager>();
        randomEventManagerScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomEventManager>();
        reducePopPercentBy = reducePopPercentBy * 0.01f;
        reduceAirBy = reduceAirBy * 0.01f;
        reduceFuelBy = reduceFuelBy * 0.01f;
        reduceFoodBy = reduceFoodBy * 0.01f;
        eventEnd = false;
        pauseTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {

            timeLeft = eventLength - (Time.time - startTime);
            float timeToDestroyReached = Time.time - destroyCalledTime;

            if (timeLeft > 0 && eventEnd == false)
            {
                countDown.text = timeLeft.ToString("#.0");
            }


            if (timeLeft <= 0 && eventEnd == false)
            {
                EventOver();
                countDown.text = ("TIME OVER");
            }

            if (eventEnd == true && timeToDestroyReached >= 2)
            {

                print("calling destroy Event");
                DestroySelf();
            }


        
	}

    void EventOver() {
        //riotCalculations
        if (isThisPopulationThreatening == true && (fleetManagerScript.securityJob/fleetManagerScript.fleetTotalPopulation*100f) < minSecurityLevel)
        {
            
            print("reducing population by ");
            fleetManagerScript.totalFleetPopR = fleetManagerScript.totalFleetPopR - Mathf.RoundToInt(fleetManagerScript.totalFleetPopR * reducePopPercentBy); ;
            fleetManagerScript.totalFleetPopG = fleetManagerScript.totalFleetPopG - Mathf.RoundToInt(fleetManagerScript.totalFleetPopG * reducePopPercentBy);
            fleetManagerScript.totalFleetPopB = fleetManagerScript.totalFleetPopB - Mathf.RoundToInt(fleetManagerScript.totalFleetPopB * reducePopPercentBy);
            fleetManagerScript.foodJobR = fleetManagerScript.foodJobR - Mathf.RoundToInt(fleetManagerScript.foodJobR * reducePopPercentBy);
            fleetManagerScript.foodJobG = fleetManagerScript.foodJobG - Mathf.RoundToInt(fleetManagerScript.foodJobG * reducePopPercentBy);
            fleetManagerScript.foodJobB = fleetManagerScript.foodJobB - Mathf.RoundToInt(fleetManagerScript.foodJobB * reducePopPercentBy);
            fleetManagerScript.airJobR = fleetManagerScript.airJobR - Mathf.RoundToInt(fleetManagerScript.airJobR * reducePopPercentBy);
            fleetManagerScript.airJobG = fleetManagerScript.airJobG - Mathf.RoundToInt(fleetManagerScript.airJobG * reducePopPercentBy);
            fleetManagerScript.airJobB = fleetManagerScript.airJobB - Mathf.RoundToInt(fleetManagerScript.airJobB * reducePopPercentBy);
            fleetManagerScript.fuelJobR = fleetManagerScript.fuelJobR - Mathf.RoundToInt(fleetManagerScript.fuelJobR * reducePopPercentBy);
            fleetManagerScript.fuelJobG = fleetManagerScript.fuelJobG - Mathf.RoundToInt(fleetManagerScript.fuelJobG * reducePopPercentBy);
            fleetManagerScript.fuelJobB = fleetManagerScript.fuelJobB - Mathf.RoundToInt(fleetManagerScript.fuelJobB * reducePopPercentBy);
            fleetManagerScript.joblessR = fleetManagerScript.joblessR - Mathf.RoundToInt(fleetManagerScript.joblessR * reducePopPercentBy);
            fleetManagerScript.joblessG = fleetManagerScript.joblessG - Mathf.RoundToInt(fleetManagerScript.joblessG * reducePopPercentBy);
            fleetManagerScript.joblessB = fleetManagerScript.joblessB - Mathf.RoundToInt(fleetManagerScript.joblessB * reducePopPercentBy);
            eventName.text = (failureString);
            
        }
        else if (isThisPopulationThreatening == true && (fleetManagerScript.securityJob / fleetManagerScript.fleetTotalPopulation * 100f) >= minSecurityLevel)
        {
            eventName.text = (successString);
            
        }

        fleetManagerScript.fleetSystemFood = fleetManagerScript.fleetSystemFood - Mathf.RoundToInt(fleetManagerScript.fleetSystemFood * reduceFoodBy);
        fleetManagerScript.fleetSystemAir = fleetManagerScript.fleetSystemAir - Mathf.RoundToInt(fleetManagerScript.fleetSystemAir * reduceAirBy);
        fleetManagerScript.fleetSystemFuel = fleetManagerScript.fleetSystemFuel - Mathf.RoundToInt(fleetManagerScript.fleetSystemFuel * reduceFuelBy);

        eventEnd = true;
        eventEndDisplay.text = ("Population reduced by" + "\n " + reducePopPercentBy*100 + " percent" + "\n " +"Food reduced by" + "\n " + reduceFoodBy * 100 + "\n " +"Air reduced by" + "\n " +reduceAirBy * 100 + "\n " +"Fuel reduced by" + "\n " + reduceFuelBy * 100);
        eventName.text = (failureString);
        randomEventManagerScript.lastEventTime = Time.time;
        destroyCalledTime = Time.time;
        print("Event Over");
        
    }
    public void DestroySelf() {
;
            Destroy(gameObject);

    }
}
