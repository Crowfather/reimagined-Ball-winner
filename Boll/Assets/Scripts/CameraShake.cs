using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    GameObject cam;
    public float shakeSensitivity;
    //Rigidbody rb;

	// Use this for initialization
	void Start () {
        cam = GameObject.Find("Main Camera");
        //rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.relativeVelocity.magnitude);

        if (other.gameObject.CompareTag("Wall")) //vid kollision, kolla om det andra objektet är en vägg
        {
            if (other.relativeVelocity.magnitude > shakeSensitivity) //kolla om kollisionen var kraftig nog
            {
                float shakeForce = other.relativeVelocity.magnitude;// - shakeSensitivity;
                StopAllCoroutines();
                StartCoroutine(cameraShake(shakeForce));
            }
        }
    }

    IEnumerator cameraShake(float magnitude)
    {
        float progress = 0;
        float angle;

        Debug.Log("Shake shake");

        while (progress < magnitude)
        {
            //angle = Random.Range(-magnitude, magnitude);
            angle = Mathf.PerlinNoise(progress, 1 - progress); //perlinnoise genererar en mjuk men slumpmässig kurva
            cam.transform.eulerAngles = new Vector3(45, 0, angle); //ändra vinkel på kameran

            progress += 0.05f;

            yield return new WaitForSeconds(0.05f);
        }

        cam.transform.eulerAngles = new Vector3(45, 0, 0); //gå tillbaka till kamerans vanliga vinkel
    }
}
