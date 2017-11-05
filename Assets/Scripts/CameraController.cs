using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private PlayerController thePlayer;
    private Vector3 lastPlayerPosition;
    private Transform transform;

    public float offset;
    private float count;
    private float distanceToMove;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
        transform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        /*distanceToMove = thePlayer.transform.position.y - lastPlayerPosition.y;
        if(distanceToMove > 0)
        {

        }
        count = count + 1;
        if(count > offset) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);
            lastPlayerPosition = thePlayer.transform.position;
        }*/
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "CameraPoint")
        {
            transform.position = new Vector3(transform.position.x, gameObject.transform.position.y, transform.position.z);
            Debug.Log("Camera Point");
        }

    }

}
