using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomisePortholeColor : MonoBehaviour {
    public Material[] PopulationColors;
    public Animator myAnim;
    public Renderer populationRenderer;
    float colour;
    float randomAnimTime;
	// Use this for initialization
	void Start () {
        randomAnimTime = Mathf.RoundToInt(Random.Range(0, 60));
        myAnim = gameObject.GetComponent<Animator>();
        colour = Random.Range(0, PopulationColors.Length);
        populationRenderer.material = PopulationColors[Mathf.RoundToInt(colour)];
        
	}
    private void OnEnable()
    {
        myAnim.Play("Idle", 0, randomAnimTime);
    }


}
