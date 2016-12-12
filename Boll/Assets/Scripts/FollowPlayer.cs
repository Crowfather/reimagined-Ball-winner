using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position; //offset mellan bollen och kameran
        
	}

    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //flytta kameran varje frame
        
    }
}
