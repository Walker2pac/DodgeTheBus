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

	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        lastPlayerPosition = thePlayer.transform.position;
        transform = GetComponent<Transform>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "CameraPoint")
        {
            transform.position = new Vector3(transform.position.x, gameObject.transform.position.y + 4, transform.position.z);
            Debug.Log("Camera Point");
        }

    }

}
