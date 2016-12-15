using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

    public float speed;
    Vector3 angle;
    Transform t;

	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        angle = t.eulerAngles; //Default rotation
	}
	
	// Update is called once per frame
	void Update () {
        t.eulerAngles = angle;
        angle.y += speed; //Ändrar bara y rotationen
        if (angle.y > 360)
        {
            angle.y -= 360;
        }
	}
}
