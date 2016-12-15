using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class finish : MonoBehaviour {

    GameObject player;
    Rigidbody rb;
    public string nextLevel = null;
    public ParticleSystem particles;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(EndEffects());

            particles.Play();
        }
    }

    void OnTriggerEnter(Collider other)
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

    IEnumerator EndEffects() //stoppa bollen efter .5 sekunder, förutsatt att den inte är på marken. Då kan man fortsätta knuffa på den
    {                           //Byt sedan bana efter 2 sekunder
        yield return new WaitForSeconds(0.5f);

        rb.velocity = Vector3.zero;
        rb.useGravity = false;

        yield return new WaitForSeconds(2f);

        changeLevel();
    }
}
