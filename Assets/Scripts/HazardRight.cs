using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardRight : MonoBehaviour {

	private Vector3 defaultPosition;
	private Transform transform;
	private Vector3 position;
	private Rigidbody2D rigidbody;

	public float speed;
	public float spawnPositionX; //переменная Х где появляется коробка после столкновения с Boundary
	private float marginY;
	private bool isRotated;

	void Start () {
		transform = GetComponent<Transform>();
		Debug.Log (rigidbody + "");
		rigidbody = GetComponent<Rigidbody2D> ();
		Debug.Log (rigidbody + "");
		defaultPosition = new Vector3(spawnPositionX, transform.position.y, transform.position.z);
		position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		marginY = 1.14F;
		isRotated = false;
	}

	void Update () { 
		position.x += speed * Time.deltaTime;
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
