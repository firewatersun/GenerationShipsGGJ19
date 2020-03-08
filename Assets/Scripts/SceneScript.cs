using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadMainGameScene()
    {
        SceneManager.LoadScene("MainSceneNoTutorial");
    }
    public void LoadTutorial()
    {
        print("reloadingFromTutorial");
        SceneManager.LoadScene("Intro and Tutorial");
    }
}
