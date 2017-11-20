using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private GroupOfHazards groupOfHazards; //Объект SpawnPositionRight на сцене

    private Vector3 defaultPosition;
    private Vector3 spawnPosition; //хранит в себе координаты объекта SpawnPositionRight на сцене
    private Transform transform;
    private Vector3 position;
    private Rigidbody2D rigidbody;

    private float speed;

	void Start () {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        spawnPosition = gameObject.GetComponentInParent<GroupOfHazards>().getSpawnPosition();
        speed = gameObject.GetComponentInParent<GroupOfHazards>().getMovementSpeed();
        defaultPosition = new Vector3(spawnPosition.x, transform.position.y, transform.position.z);
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void Update () {      
	}
    void FixedUpdate()
    {
        rigidbody.velocity = (Vector3.right * -1) * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Boundary")
        {
            transform.position = defaultPosition;
        }

    }
}
