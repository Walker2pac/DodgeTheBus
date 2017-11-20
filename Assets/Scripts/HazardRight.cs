using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRight : MonoBehaviour {

	private Vector3 defaultPosition;
    private Rigidbody2D rigidbody;
	private Transform transform;
	private Vector3 position;
    private Vector3 spawnPosition; //хранит в себе координаты объекта SpawnPositionRight на сцене


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
        rigidbody.velocity = (Vector3.right * 1)  * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Boundary")
        {
            transform.position = defaultPosition;
        }

    }

}
