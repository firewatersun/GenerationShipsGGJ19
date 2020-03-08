using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvasScript : MonoBehaviour {
    public TimelineManager tmMan;
    public float readTime;
    float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
        tmMan.gameEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
        tmMan.gameEnd = false;
        float elapsedTime = Time.time - startTime;
        if (elapsedTime >= readTime)
        {
            DestroyStartCanvas();
            
        }
	}

    public void DestroyStartCanvas() {
        tmMan.gameEnd = false;
        Destroy(this.gameObject);
    }
}
