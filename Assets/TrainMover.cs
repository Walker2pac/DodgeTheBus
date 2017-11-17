using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour {

    private Transform transform;
    private Vector3 position;

    private float speed = 3F;

	void Start () {
        transform = GetComponent<Transform>();
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	void FixedUpdate () {
        position.x -= speed * Time.deltaTime;
        transform.position = position;
	}
}
