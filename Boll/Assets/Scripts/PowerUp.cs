using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    Renderer rend;
    //Color defaultColor;
    Color newColor;
    Color currentColor;
    //bool activate = false;
    //float timer = 20;
    float duration = 3;
    float smoothness = 0.02f;

    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        currentColor = /*defaultColor =*/ rend.material.color;
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //Förhindrar att skärmen släcker sig
	}
	
	// Update is called once per frame
	void Update () {
	    /*if(activate)
        {
            timer -= Time.deltaTime;                Det här var ett test för att se om det gick att ge en temporär powerup
            //Debug.Log(timer);                     Funkade skitbra
        }

        if (timer <= 0 && activate)
        {
            activate = false;
            StartCoroutine(LerpColor(newColor, defaultColor));
            //rend.material.color = Color.Lerp(newColor, defaultColor, 1);
        }*/

        rend.material.color = currentColor;
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            //rend.material.SetColor(0, Color.black);
            //activate = true;
            //changeColor();
            newColor = other.gameObject.GetComponent<Renderer>().material.color;
            StopAllCoroutines();
            StartCoroutine(LerpColor(currentColor, newColor));  // coroutine = asynkron funktion tror jag
            //rend.material.color = new Color(0, 0, 0);
        }
    }

    IEnumerator LerpColor(Color from, Color to) //Linjär interpolerar från en färg till en annan över duration sekunder med smoothness mjukhet
    {
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            Debug.Log(newColor);
            currentColor = Color.Lerp(from, to, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
    }
}

