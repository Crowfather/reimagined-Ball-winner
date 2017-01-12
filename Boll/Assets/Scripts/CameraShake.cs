using UnityEngine;
using System.Collections;
using System;

public class CameraShake : MonoBehaviour {

    GameObject cam;
    FollowPlayer fulHax;
    public float shakeSensitivity;
<<<<<<< HEAD

    //Rigidbody rb;
=======
    public float shakeMagnitudeMultiplier;
    public float maxShake;
    enum tilt { left, leftmid, right, rightmid };
>>>>>>> origin/master

    // Use this for initialization
    void Start () {
        cam = GameObject.Find("Main Camera");
        fulHax = cam.GetComponent<FollowPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            StartCoroutine(cameraShake(5)); //Test
	}

    void OnCollisionEnter(Collision other)
    {
        Vibration.Vibrate(1000);
        Debug.Log(other.relativeVelocity.magnitude);
        
        if (other.gameObject.CompareTag("Wall")) //vid kollision, kolla om det andra objektet är en vägg
        {
            //Handheld.Vibrate();
            if (other.relativeVelocity.magnitude > shakeSensitivity) //kolla om kollisionen var kraftig nog
            {
                float shakeForce = other.relativeVelocity.magnitude;

                if (shakeForce > maxShake) shakeForce = maxShake;

                StopAllCoroutines();
                StartCoroutine(cameraShake(shakeForce));
                Vibration.Vibrate(1000);
            }
            if (other.relativeVelocity.magnitude < shakeSensitivity && other.relativeVelocity.magnitude > 0.3)
            {
                Vibration.Vibrate(500);
            }


        }
    }

    IEnumerator cameraShake(float magnitude)
    {
        float progress = 0;         //Hur långt in i skakningen vi är
        float target = magnitude;   //Hur långt vi vill gå
        float angle = 0;

        tilt camTilt = tilt.left;
        
        fulHax.lookAtPlayer = false; //gör så att kameran slutar rotera för att titta på spelaren
                                       //Det sätter knostant z rotation till 0
        Debug.Log("Shake shake"); //shake shake

        while (progress < target)
        {
            switch(camTilt)  //Kameran lutar åt vänster, ingen lutning, höger, ingen lutning, repeat
            {                   //Lather, rinse and repeat... always repeat
                case (tilt.left)://Luta vänster
                    angle = magnitude * shakeMagnitudeMultiplier;
                    camTilt = tilt.leftmid;
                    break;
                case (tilt.right)://Luta höger
                    angle = -(magnitude * shakeMagnitudeMultiplier);
                    camTilt = tilt.rightmid;
                    break;
                case (tilt.leftmid)://Ingen lutning, nästa höger
                    angle = 0;
                    camTilt = tilt.right;
                    break;
                case (tilt.rightmid)://Ingen lutning, nästa väntster
                    angle = 0;
                    camTilt = tilt.left;
                    break;
            }

            cam.transform.LookAt(transform); //Titta på spelaren, rotera sedan i z-led
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, angle);

            Debug.Log(angle);

            magnitude -= 0.1f;  //Minskar gradvis lutningen
            progress += 0.1f;
            
            yield return new WaitForSeconds(0.05f);
        }

        fulHax.lookAtPlayer = true; //kameran kan börja rotera vanligt igen
    }
}
