using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

    GameObject cam;
    FollowPlayer fulHax;
    public float shakeSensitivity;
    public float shakeMagnitudeMultiplier;
    //Rigidbody rb;

    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Main Camera");
        fulHax = cam.GetComponent<FollowPlayer>();
        //rb = player.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            StartCoroutine(cameraShake(1));
	}

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.relativeVelocity.magnitude);

        if (other.gameObject.CompareTag("Wall")) //vid kollision, kolla om det andra objektet är en vägg
        {
            if (other.relativeVelocity.magnitude > shakeSensitivity) //kolla om kollisionen var kraftig nog
            {
                float shakeForce = other.relativeVelocity.magnitude;
                StopAllCoroutines();
                StartCoroutine(cameraShake(shakeForce));
            }
        }
    }

    IEnumerator cameraShake(float magnitude)
    {
        float progress = 0;         //Hur långt in i skakningen vi är
        float target = magnitude;   //Hur långt vi vill gå
        float angle = 0;
        fulHax.lookAtPlayer = false; //gör så att kameran slutar rotera för att titta på spelaren
        //Vector3 angle = cam.transform.eulerAngles;

        Debug.Log("Shake shake"); //shake shake

        while (progress < target)
        {
            if (angle <= 0)
            {
                angle = magnitude * shakeMagnitudeMultiplier;   //Magnitude går gradvis ner med tiden och vinkeln som vi skakas i med den
            }                                                   
            else
            {                                                   
                angle = -(magnitude * shakeMagnitudeMultiplier);                                    //Vinkeln alternerar mellan vänster och höger tilt
            }                                                   //Altså mellan < 0 och > 0

            //cam.transform.Rotate(0, 0, angle);
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, angle);

            magnitude -= 0.1f;
            progress += 0.1f;

            yield return new WaitForSeconds(0.05f);
        }

        fulHax.lookAtPlayer = true; //kameran kan börja rotera vanligt igen
    }
}
