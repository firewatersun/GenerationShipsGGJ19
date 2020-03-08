using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStartStats : MonoBehaviour {
    public bool amIMainShip;
    public int StartingPopR;
    public int StartingPopG;
    public int StartingPopB;
    public float StartingPopModifier;
    //public int foodGeneration;
    //public int waterGeneration;
    //public int fuelGeneration;
    //public int airGeneration;
    public int startingFood;
    public int startingAir;
    public int startingFuel;


    // Use this for initialization
    void Start () {

    
        if (amIMainShip == true)
        {
            float RedRandomiser = Random.Range(0, StartingPopModifier*2);
            float GreenRandomiser = Random.Range(0, StartingPopModifier*2);
            float BlueRandomiser = Random.Range(-StartingPopModifier, StartingPopModifier/2);
            

            StartingPopR = Mathf.Abs(StartingPopR + Mathf.RoundToInt(RedRandomiser)*2);
            StartingPopG = Mathf.Abs(StartingPopG + Mathf.RoundToInt(GreenRandomiser)*2);
            StartingPopB = Mathf.Abs(StartingPopB + Mathf.RoundToInt(BlueRandomiser)/2);

            AddedToFleet();
        }

    }
	

	// Update is called once per frame
	public void AddedToFleet () {
        //add population
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
        gameManager.GetComponent<FleetManager>().totalFleetPopR = gameManager.GetComponent<FleetManager>().totalFleetPopR + StartingPopR;
        gameManager.GetComponent<FleetManager>().totalFleetPopG = gameManager.GetComponent<FleetManager>().totalFleetPopG + StartingPopG;
        gameManager.GetComponent<FleetManager>().totalFleetPopB = gameManager.GetComponent<FleetManager>().totalFleetPopB + StartingPopB;
        //add resources
        gameManager.GetComponent<FleetManager>().fleetSystemAir = gameManager.GetComponent<FleetManager>().fleetSystemAir + startingAir;
        gameManager.GetComponent<FleetManager>().fleetSystemFood = gameManager.GetComponent<FleetManager>().fleetSystemFood + startingFood;
        gameManager.GetComponent<FleetManager>().fleetSystemFuel = gameManager.GetComponent<FleetManager>().fleetSystemFuel + startingFuel;

       
    }
}
