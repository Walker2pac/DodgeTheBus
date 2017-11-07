using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCameraPoints : MonoBehaviour {

    public Transform transform;
    public CameraPoint cameraPoint;

    public float marginY;

	void Start () {
        Vector3 cameraPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        for (int i = 0; i < 8; i++)
        {
            cameraPosition.y = cameraPosition.y + marginY;
            Instantiate(cameraPoint, cameraPosition, transform.rotation);
        }
	}
	
	void Update () {
		
	}


}
