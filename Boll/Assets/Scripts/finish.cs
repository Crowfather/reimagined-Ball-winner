using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class finish : MonoBehaviour {

    GameObject player;
    Rigidbody rb;
    public string nextLevel;
    ParticleSystem particles;
    public Vector3 cameraLocation;
    public Vector3 cameraRotation;
    GameObject cam;
    FollowPlayer camScript;
    Player_Movement playerScript;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player_Movement>();
        rb = player.GetComponent<Rigidbody>();
        particles = GetComponentInChildren<ParticleSystem>();
        cam = GameObject.Find("Main Camera");
        camScript = cam.GetComponent<FollowPlayer>();  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other) //Om målet är en solid klump
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndEffects());

            particles.Play();
        }
    }

    void OnTriggerEnter(Collider other) //Om målet är en skithäftig portal
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndEffects());
            
            particles.Play();
        }
    }

    void changeLevel()
    {
         SceneManager.LoadScene(nextLevel);
    }

    IEnumerator EndEffects()
    { 
        camScript.enabled = false;  //förhindrar att kameran flyttar sig efter att man gått i mål
        playerScript.enabled = false;   //förhindrar att spelaren flyttar på bollen efter att man gått i mål

        cam.transform.position = cameraLocation;    //Flytta & rotera kameran
        cam.transform.eulerAngles = cameraRotation; //Vektorerna måste sättas manuellt

        yield return new WaitForSeconds(0.5f);

        rb.velocity = Vector3.zero; //stoppar bollen
        rb.useGravity = false;

        yield return new WaitForSeconds(2f);

        changeLevel(); //byt bana
    }
}
