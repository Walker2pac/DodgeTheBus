using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfHazards : MonoBehaviour {

    public Vector3 spawnPosition;

    public float movementSpeed;

    public Vector3 getSpawnPosition()
    {
        return spawnPosition;
    }
    public float getMovementSpeed()
    {
        return movementSpeed;
    }

}
