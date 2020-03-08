using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimelineManager : MonoBehaviour {
    public FleetManager fleetManagerScript;
    public RandomEventManager randomEventManagerScript;
    public GameEndCalculator gameEndCalculator;
    public Text GameOverScreen;
    public Text distanceToPlanet;
    public Image endGameBG;
    float startTime;
    float endTime;
    float gameTime;
    public float gameSuccessLength;
    public bool gameEnd;
    public AudioSource gameMusic;
    public bool pauseGame;

	// Use this for initialization
	void Start () {
        fleetManagerScript = gameObject.GetComponent<FleetManager>();
        randomEventManagerScript = gameObject.GetComponent<RandomEventManager>();
        startTime = Time.time;
        GameOverScreen.gameObject.SetActive(false);
        gameEnd = false;
        gameEndCalculator = GameObject.FindGameObjectWithTag("gameEndCalculator").GetComponent<GameEndCalculator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (GameObject.FindGameObjectWithTag("gamePausing") != null)
        {
            pauseGame = true;
            print("pausing game");
            fleetManagerScript.timelinePauseGame = true;
            randomEventManagerScript.timelinePauseGame = true;
            //gameMusic.Pause();
            Time.timeScale = 0.1f;
        }
        else if (GameObject.FindGameObjectWithTag("gamePausing") == null)
        {
            pauseGame = false;
            print("starting game");
            fleetManagerScript.timelinePauseGame = false;
            randomEventManagerScript.timelinePauseGame = false;
            //if (gameMusic.isPlaying == false)
            //{
            //    gameMusic.Play();
            //}
            Time.timeScale = 1;
        }

        gameTime = Time.time - startTime;
        int distanceInt = Mathf.RoundToInt(gameSuccessLength - gameTime);

        if (gameEnd == false || pauseGame == false)
        {
            distanceToPlanet.text = ("Time to planetfall: " + distanceInt);
        }
        

        if (gameTime>= gameSuccessLength && gameEnd == false)
        {
            if (gameEnd == false && pauseGame ==false )
            {
                float endGameTime = Mathf.RoundToInt(Mathf.Abs(endTime - startTime));
                float generations = Mathf.RoundToInt(endGameTime * 0.3f);
                fleetManagerScript.gameOver = true;
                randomEventManagerScript.gameOver = true;
                
                GameOverScreen.gameObject.SetActive(true);
                endGameBG.gameObject.SetActive(true);
                GameOverScreen.text = ("DESTINATION REACHED" + "\n" + "You Have Safely Guided " + generations + " Generations." + "\n" + "\n" + "You turned away " + gameEndCalculator.refusedB + " Bluesles" + "\n"+ "and didn't assign jobs to " + gameEndCalculator.unassignedB + " Bluesles" + "\n" + "\n" + "You were " + gameEndCalculator.biasPercentR + " percent biased in assigning Redsles to security jobs" + "\n" + "\n" + "You were " + gameEndCalculator.biasPercentG + " percent biased in assigning Greenies to production jobs" + "\n" +"\n" + "In reality, all populations had the exact same statistics") ;
            }

            gameEnd = true;
        }

        if (fleetManagerScript.fleetSystemAir <= 0 || fleetManagerScript.fleetSystemFood <= 0 || fleetManagerScript.fleetSystemFuel <= 0 && gameEnd == false)
        {
            print("you died");
            if (gameEnd == false)
            {
                endTime = Time.time;
                float endGameTime = Mathf.RoundToInt(Mathf.Abs(endTime - startTime));
                fleetManagerScript.gameOver = true;
                randomEventManagerScript.gameOver = true;
                float generations = Mathf.RoundToInt(endGameTime * 0.3f);
                GameOverScreen.gameObject.SetActive(true);
                endGameBG.gameObject.SetActive(true);
                GameOverScreen.text = ("GAME OVER" + "\n" + "You Survived For " + generations + " Generations.");
            }

      
            gameEnd = true;

            //print("Game Over" + fleetManagerScript.fleetSystemAir);
        }


	}
}
