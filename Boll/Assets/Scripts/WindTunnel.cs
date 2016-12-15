using UnityEngine;
using System.Collections;

public class WindTunnel : MonoBehaviour {

    GameObject player;
    Rigidbody rb;
    public Vector3 windForce; //Riktning vinden knuffar i       !!OBS!! WORLD SPACE, INTE I RELATION TILL OBJEKTET
                                                                // Partikeleffekten måste justeras manuellt
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");         //      Om en cylinder inte passar är det bara att byta ut collidern mot någon annan
        rb = player.GetComponent<Rigidbody>();      //      Bara den är en trigger så borde allt fungera iaf
	}                                               //

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            rb.AddForce(windForce); //Knuffa bollen
        }
    }
}
