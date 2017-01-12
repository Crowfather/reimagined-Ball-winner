using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    GameObject player;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero; //?????
    [HideInInspector] public bool lookAtPlayer = true;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position; //offset mellan bollen och kameran
        
	}

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, 0.3f); //Flyttar kameran all smooth-like
        if (lookAtPlayer) transform.LookAt(player.transform); //Kameran roterar så att den alltid tittar på bollen, om kameran inte skakar - se cameraShake
    }
}
