using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;


public class Player_Movement : MonoBehaviour {

    private Rigidbody rb;
    public float forceMultiplier;
    public float jumpPower;
    public LayerMask terrain;    
    public float groundCheckRadius; //Storleken på sfären som kollar om bollen är på marken, bollen i sig har en radius på 0.25
    bool grounded = false;
    public float jumpSensitivity;
    [HideInInspector] public float moveHori;
    [HideInInspector] public float moveVert;
    [HideInInspector] public float moveUp;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate()
    {
        moveHori = (float) Math.Round(Input.acceleration.x, 2);
        moveVert = (float) Math.Round(Input.acceleration.y, 2);
        moveUp = 0;
        
        grounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z), groundCheckRadius, terrain); //kollar om bollen är på marken eller inte genom att 
        //Debug.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckRadius, transform.position.z));    // rita en sfär runt och se om den rör vid specifikt
                                                                                                                                                   //layer. All mark har terrain som layer
        if (grounded && Input.acceleration.z > jumpSensitivity) moveUp = 1; //Om bollen är på marken och tillräcklig z-fart, hoppa

        Vector3 movement = new Vector3(moveHori, moveUp * jumpPower, moveVert);
        rb.AddForce(movement * forceMultiplier * 2); //Knuffa bollen efter att ha multiplicerat kraften

    }

    void LateUpdate()
    {
        //Debug.Log(grounded);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < -30) //starta om om bollen kommer för långt ner
        {
            SceneManager.LoadScene(0);
        }
	    
	}
}
