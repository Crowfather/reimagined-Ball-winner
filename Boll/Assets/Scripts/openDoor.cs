using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

    public GameObject [] buttons; //Vilka power ups som måste plockas upp för att öppna
    public float openAngle;
    bool open = false;
    public enum turnAroundAxis {x, y, z};
    public turnAroundAxis axis; //Axeln som dörren ska öppnas längs
    Vector3 defaultRotations;

	// Use this for initialization
	void Start () {
        defaultRotations = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        if (!open)
        {
            open = true;

            for (int x = 0; x < buttons.Length; x++) //Loopar igenom arrayen och kollar om alla object är null, alltså plockade
            {
                if (buttons[x] != null)
                {
                    open = false;
                }
            }

            if (open)
            {
                StartCoroutine(openTheDoor());
            }
        }
	}

    IEnumerator openTheDoor() //Öppnar gradvis dörren längs given axel över 100 steg och 1 sekund
    {
        float angle = 0;
        float progress = 0;

        while (progress <= 1)
        {
            angle = Mathf.Lerp(0, openAngle, progress);

            switch (axis)
            {
                case turnAroundAxis.x:
                    transform.eulerAngles = new Vector3(angle, defaultRotations.y, defaultRotations.z);
                    break;
                case turnAroundAxis.y:
                    transform.eulerAngles = new Vector3(defaultRotations.x, angle, defaultRotations.z);
                    break;
                case turnAroundAxis.z:
                    transform.eulerAngles = new Vector3(defaultRotations.x, defaultRotations.y, angle);
                    break;
            }

            progress += 0.01f;

            yield return new WaitForSeconds(0.01f);
        }

        
    }
}
