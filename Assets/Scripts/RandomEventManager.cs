using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventManager : MonoBehaviour {
    public float randomEventIntervalMin;
    public float randomEventIntervalMax;
    float currentRandomEventInterval;
    public float lastEventTime;
    public bool eventHappening;
    public GameObject[] randomEvents;
    public bool gameOver;
    public bool timelinePauseGame;

    // Use this for initialization
    void Start () {
        gameOver = false;
        currentRandomEventInterval = Random.Range(randomEventIntervalMin, randomEventIntervalMax);
        lastEventTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("randomEvent") == null)
        {
            eventHappening = false;
        }
        else if (GameObject.FindGameObjectWithTag("randomEvent") != null)
        {
            eventHappening = true;
        }
        
        if (eventHappening == false && gameOver == false)
        {
            float currentTime = Time.time;
            if (currentTime-lastEventTime >= currentRandomEventInterval)
            {

                    CallEvent();
                    eventHappening = true;
                    currentRandomEventInterval = Random.Range(randomEventIntervalMin, randomEventIntervalMax);

                //EVENT HAPPENS

            }
        }
	}

    void CallEvent() {
        int currentEvent = Mathf.RoundToInt(Random.Range(0, randomEvents.Length));
        GameObject.Instantiate(randomEvents[currentEvent]);
    }
}
