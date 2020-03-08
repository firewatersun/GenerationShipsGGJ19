using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipSpawner : MonoBehaviour {
    public GameObject[] spawnpoints;
    public ShipStartStats shipStatScript;
    public GameObject shipToSpawn;
    public float minResourceCount;
    public float maxResourceCount;
    //UI calls
    public Text popCountNType;
    public Text airCount;
    public Text foodCount;
    public Text fuelCount;
    public Text timeToChooseText;
    //public float timer info
    public float minTime;
    public float maxTime;
    float enabledTime;
    float timeToChoose;
    //randomeventmanager
    public RandomEventManager randEvMan;
    public GameEndCalculator gameEndCalculator;

    // Use this for initialization
    void Start () {
        spawnpoints = GameObject.FindGameObjectsWithTag ("spawnpoint");
        randEvMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<RandomEventManager>();
        gameEndCalculator = GameObject.FindGameObjectWithTag("gameEndCalculator").GetComponent<GameEndCalculator>();
    }

    private void OnEnable()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("spawnpoint");
        randEvMan = GameObject.FindGameObjectWithTag("GameController").GetComponent < RandomEventManager>();
        gameEndCalculator = GameObject.FindGameObjectWithTag("gameEndCalculator").GetComponent<GameEndCalculator>();
        enabledTime = Time.time;
        timeToChoose = Mathf.RoundToInt(Random.Range(minTime, maxTime));
        shipStatScript = GetComponentInChildren<ShipStartStats>();
        shipToSpawn = shipStatScript.gameObject;

        int howMuchFood = Mathf.RoundToInt(Random.Range(minResourceCount, maxResourceCount));
        int howMuchAir = Mathf.RoundToInt(Random.Range(minResourceCount, maxResourceCount));
        int howMuchFuel = Mathf.RoundToInt(Random.Range(minResourceCount, maxResourceCount));
        //show food air fuel in UI
        airCount.text = (howMuchAir + " AIR");
        foodCount.text = (howMuchFood + " FUEL");
        fuelCount.text = (howMuchFuel + " FOOD");

        //population randomiser
        int whichPopulation = Mathf.RoundToInt(Random.Range(0,6));
        int populationModifier = Mathf.RoundToInt(Random.Range(0, shipStatScript.StartingPopModifier));

        if (whichPopulation>=0 && whichPopulation <1)
        {
            shipStatScript.StartingPopR = shipStatScript.StartingPopR + populationModifier;
            shipStatScript.StartingPopG = 0;
            shipStatScript.StartingPopB = 0;

            shipStatScript.startingFood = howMuchFood;
            shipStatScript.startingAir = howMuchAir;
            shipStatScript.startingFuel = howMuchFuel;

            popCountNType.text = ("Population On Board: "+ "\n" + "\n" + shipStatScript.StartingPopR + " Redsles" + "\n" + "\n" + "Redsles are strong and resilient, great in security and defence roles, but low in intelligence");
        }

        else if (whichPopulation >= 1 && whichPopulation < 2)
        {
            shipStatScript.StartingPopR = 0;
            shipStatScript.StartingPopG = shipStatScript.StartingPopG + populationModifier;
            shipStatScript.StartingPopB = 0;

            shipStatScript.startingFood = howMuchFood;
            shipStatScript.startingAir = howMuchAir;
            shipStatScript.startingFuel = howMuchFuel;

            popCountNType.text = ("Population On Board: " + "\n" + "\n" + shipStatScript.StartingPopG + " Greenies" + "\n" + "\n" + "Greenies are very intelligent and good at production, but not very good in conflict");
        }

        else if (whichPopulation >= 2 && whichPopulation <= 6)
        {
            shipStatScript.StartingPopR = 0;
            shipStatScript.StartingPopG = 0;
            shipStatScript.StartingPopB = shipStatScript.StartingPopG + populationModifier;

            shipStatScript.startingFood = howMuchFood;
            shipStatScript.startingAir = howMuchAir;
            shipStatScript.startingFuel = howMuchFuel;

            popCountNType.text = ("Population On Board: " + "\n" + "\n" + shipStatScript.StartingPopB + " Bluehoos" + "\n" + "\n" + "Bluehoos are sad all the time, don't work well with others and consume large quantities of food and air");
        }

    }

    // Update is called once per frame
    void Update () {
        float timeleft = (timeToChoose+ enabledTime)-Time.time;
        timeToChooseText.text = timeleft.ToString("#.0");
        if (Time.time - enabledTime >= timeToChoose)
        {
            DestroySelf();
        }
	}

    public void SpawnThisShip() {
        int whichSpawnPoint;
        whichSpawnPoint = Mathf.RoundToInt(Random.Range(0, spawnpoints.Length));

        GameObject chosenSpawnPoint = spawnpoints[whichSpawnPoint];

        if (chosenSpawnPoint.GetComponent<SpawnPointScript>().occupied == false)
        {
            
         
            Quaternion zeroRot = Quaternion.Euler(0,0,0);
            Vector3 zeroPos = new Vector3(0, 0, 0);
            shipToSpawn.transform.SetPositionAndRotation(zeroPos, zeroRot);
            GameObject spawnedShip = GameObject.Instantiate(shipToSpawn, chosenSpawnPoint.transform, false);
            chosenSpawnPoint.GetComponent<SpawnPointScript>().occupied = true;
            spawnedShip.GetComponentInChildren<ShipStartStats>().AddedToFleet();
        }
        else if (chosenSpawnPoint.GetComponent<SpawnPointScript>().occupied == true)
        {
            SpawnThisShip();
        }
    }

    public void RefusedShip() {
        gameEndCalculator.refusedR += shipStatScript.StartingPopR;
        gameEndCalculator.refusedG += shipStatScript.StartingPopG;
        gameEndCalculator.refusedB += shipStatScript.StartingPopB;
    }

    public void DestroySelf() {
        randEvMan.lastEventTime = Time.time;
        Destroy(gameObject);
    }
}
