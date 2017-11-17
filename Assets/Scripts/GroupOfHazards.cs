using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfHazards : MonoBehaviour {

    public Transform transformSpawnPosition;
    private Vector3 spawnPosition;

	void Start () {
        spawnPosition = transformSpawnPosition.position;
	}

    public Vector3 getSpawnPosition()
    {
        return spawnPosition;
    }

}
