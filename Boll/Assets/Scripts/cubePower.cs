using UnityEngine;
using System.Collections;

public class cubePower : MonoBehaviour {

    public GameObject cubeMesh;
    public GameObject sphereMesh;
    public int powerUpTime = 10;
    public float extraTime = 5;

    float currentTime = 0;
    Player_Movement script;

	// Use this for initialization
	void Start () {
        script = gameObject.GetComponent<Player_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("g")) theSwitch();

        if (script.isCube) //om spelaren är kubad, öka timer
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= powerUpTime) //avkuba spelaren när kub-tiden är nådd
        {
            currentTime = 0;
            theSwitchBack();
        }
	}

    void OnColissionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("cube_power")) //Om spelaren kolliderar med något taggat som cube_power
        {
            if (!script.isCube) //om spelaren inte är en kub...
            {
                theSwitch(); //...förvandla till kub...
            }
            else //...annars förläng kub-tiden
            {
                currentTime -= extraTime;
            }

            Destroy(other.gameObject); //förstör objektet
        }
    }

    void theSwitch()
    {
        if (!script.isCube)
        {
            gameObject.GetComponent<MeshFilter>().mesh = cubeMesh.GetComponent<MeshFilter>().sharedMesh;    //Byter bollens mesh till en kub istället
            gameObject.GetComponent<SphereCollider>().enabled = false;                                      //Avaktiverar den bollformade collidern
            gameObject.GetComponent<BoxCollider>().enabled = true;                                          //och aktiverar den kubformade istället

            script.isCube = true;
            script.airControll = true;  //tillåt luft-kontroll
        }
    }

    void theSwitchBack()
    {
        gameObject.GetComponent<MeshFilter>().mesh = sphereMesh.GetComponent<MeshFilter>().sharedMesh; //Byter kubens mesh till en boll
        gameObject.GetComponent<SphereCollider>().enabled = true;                                       //Aktiverar den bollformade collidern
        gameObject.GetComponent<BoxCollider>().enabled = false;                                         //och avaktiverar den kubformade

        script.isCube = false;
        script.airControll = false; //tillåt inte luft-kontroll
    }
}
