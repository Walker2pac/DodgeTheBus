using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    private GroupOfHazards groupOfHazards; //Объект SpawnPositionRight на сцене

    private Vector3 defaultPosition;
    private Vector3 spawnPosition; //хранит в себе координаты объекта SpawnPositionRight на сцене
    private Transform transform;
    private Vector3 position;

    public float speed;
    private string nameOfSpawn;

	void Start () {
        transform = GetComponent<Transform>();
        spawnPosition = gameObject.GetComponentInParent<GroupOfHazards>().getSpawnPosition();
        defaultPosition = new Vector3(spawnPosition.x, transform.position.y, transform.position.z);
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
}
