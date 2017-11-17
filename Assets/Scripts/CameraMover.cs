using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public Camera camera;
    private Vector3 cameraCoordinates;
    private float rangePerFrame;

	void Start () {
        cameraCoordinates = camera.transform.position;
        rangePerFrame = 0.12F;
	}
	
    void OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Player") {
            StartCoroutine(CameraMovementCoroutine());
        }
    }

    IEnumerator CameraMovementCoroutine()
    {
        int count = 1;
        int totalCount = 50;
        while (totalCount > count)
        {
            count = count + 1;
            cameraCoordinates.y = cameraCoordinates.y + rangePerFrame;
            camera.transform.position = cameraCoordinates;
            yield return null;
        }
        if (totalCount == count)
        {
            Destroy(this);
        }
    }
}
