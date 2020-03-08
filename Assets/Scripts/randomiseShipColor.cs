using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomiseShipColor : MonoBehaviour {
    public Material[] PopulationColors;
    public Renderer shipRenderer;
    float colour;
    // Use this for initialization
    void Start()
    {
        colour = Random.Range(0, PopulationColors.Length);
        shipRenderer.material = PopulationColors[Mathf.RoundToInt(colour)];
    }

    void OnEnable()
    {
        colour = Random.Range(0, PopulationColors.Length);
        shipRenderer.material = PopulationColors[Mathf.RoundToInt(colour)];
    }


}
