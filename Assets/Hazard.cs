using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private Vector3 defaultPosition;
    private Transform transform;
    private Vector3 position;

    public float speed;
    private float marginY;
    private bool isRotated;

	void Start () {
        //Debug.Log("" + defaultPosition.x + defaultPosition.y + defaultPosition.z);
        transform = GetComponent<Transform>();
        //Debug.Log("" + transform.position.x + transform.position.y);
        defaultPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        marginY = 1.14F;
        isRotated = false;
	}
	
	void FixedUpdate () {
        position.x -= speed * Time.deltaTime;
        transform.position = position;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Boundary1")
        {
            position = defaultPosition;
            Debug.Log("trigger1");
        }
        if (coll.gameObject.tag == "Boundary2")
        {
            if(isRotated == false) 
            {
                defaultPosition.y += marginY;
                isRotated = true;
            }
            position = defaultPosition;
            Debug.Log("trigger2");

        }
        if (coll.gameObject.tag == "Boundary3")
        {
            if (isRotated == false)
            {
                defaultPosition.y = marginY * 2 + defaultPosition.y;
                isRotated = true;
            }
            position = defaultPosition;
            Debug.Log("trigger3");

        }
        if (coll.gameObject.tag == "Boundary4")
        {
            if (isRotated == false)
            {
                defaultPosition.y = marginY * 3 + defaultPosition.y;
                isRotated = true;
            }
            position = defaultPosition;
            Debug.Log("trigger4");

        }
/*        if (coll.gameObject.tag == "Hazard")
        {
            Debug.Log("Hazard collider");
        }*/

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Boundary1") 
        {
            Debug.Log("Collision");
        }
    }

}
