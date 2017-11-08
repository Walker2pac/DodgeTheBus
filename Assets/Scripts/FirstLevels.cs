using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevels : MonoBehaviour {

    public Hazard hazard;
    public HazardRight hazardRight;
    public Transform spawnPositionRight;
    public Transform spawnPositionLeft;
    public GameObject boundary;

    public int sizeOfHazards;
    public int firstLineSpacing, secondLineSpacing, thirdLineSpacing;
    private float marginX = 1.14F;

	void Start () {
        spawnFirstLine();
	}

    void spawnFirstLine()
    {
        Vector3 spawnPosition = new Vector3(spawnPositionRight.position.x - 2, spawnPositionRight.position.y + 1, spawnPositionRight.position.z);
        for (int i = 0; i < sizeOfHazards; i++)
        {
            if(i == firstLineSpacing || i == firstLineSpacing + 1 || i == firstLineSpacing + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, spawnPositionRight.rotation);
                spawnPosition.x -= marginX;
            }
        }
        spawnPosition.x = spawnPosition.x - 2;
        Instantiate(boundary, spawnPosition, spawnPositionRight.rotation);
        
    }
}
