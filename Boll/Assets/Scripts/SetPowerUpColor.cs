using UnityEngine;
using System.Collections;

public class SetPowerUpColor : MonoBehaviour {

    public Color newColor;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
