using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccelerationCheck : MonoBehaviour {
    //Skriver ut bollens fart
    //public GameObject player;
    Text text;
    GameObject player;
    Player_Movement script;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        player = GameObject.Find("Player");
        script = player.GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "X = " + script.moveHori + "    Y = " + script.moveVert + "    Z = " + script.moveUp;
	}
}
