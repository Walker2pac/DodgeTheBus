using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private Vector3 defaultPosition;
    private Transform transform;
    private Vector3 position;

    public float speed;
    public float spawnPositionX;
    private float marginY;
    private bool isRotated;
    private float transformPositionX; //содержит в себе координаты респа по X - эти данные нигде не меняются

	void Start () {
        transform = GetComponent<Transform>();
        defaultPosition = new Vector3(spawnPositionX, transform.position.y, transform.position.z);
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transformPositionX = transform.position.x;
        marginY = 1.14F;
        isRotated = false;
	}
	
	void FixedUpdate () {      
        position.x -= speed * Time.deltaTime;
        transform.position = position;
	}

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Boundary")
        {
            position = defaultPosition;
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Boundary1") 
        {
            Debug.Log("Collision");
        }
    }

}
