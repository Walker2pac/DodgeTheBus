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
    public int Line1Spacing, Line2Spacing, Line3Spacing, Line4Spacing, Line5Spacing, Line6Spacing;
    private float marginX = 1.14F;

	void Start () {
        spawn1Line();
        spawn2Line();
        spawn3Line();
        spawn4Line();
	}

    void spawn1Line()
    {
        Vector3 spawnPosition = new Vector3(spawnPositionRight.position.x - 2, spawnPositionRight.position.y + 1, spawnPositionRight.position.z);
        for (int i = 0; i < sizeOfHazards; i++)
        {
            if (i == Line1Spacing || i == Line1Spacing + 1 || i == Line1Spacing + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, spawnPositionRight.rotation);
                spawnPosition.x -= marginX;
            }
        }
        spawnPosition.x = spawnPosition.x - 0.2F;
        Instantiate(boundary, spawnPosition, spawnPositionRight.rotation);
    }
    void spawn2Line()
    {
        Vector3 spawnPosition = new Vector3(spawnPositionRight.position.x - 2, spawnPositionRight.position.y + 4, spawnPositionRight.position.z);
        for (int i = 0; i < sizeOfHazards; i++)
        {
            if (i == Line2Spacing || i == Line2Spacing + 1 || i == Line2Spacing + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, spawnPositionRight.rotation);
                spawnPosition.x -= marginX;
            }
        }
        spawnPosition.x = spawnPosition.x - 0.2F;
        Instantiate(boundary, spawnPosition, spawnPositionRight.rotation);
    }
    void spawn3Line()
    {
        Vector3 spawnPosition = new Vector3(spawnPositionRight.position.x - 2, spawnPositionRight.position.y + 8, spawnPositionRight.position.z);
        for (int i = 0; i < sizeOfHazards; i++)
        {
            if (i == Line3Spacing || i == Line3Spacing + 1 || i == Line3Spacing + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, spawnPositionRight.rotation);
                spawnPosition.x -= marginX;
            }
        }
        spawnPosition.x = spawnPosition.x - 0.2F;
        Instantiate(boundary, spawnPosition, spawnPositionRight.rotation);
    }
    void spawn4Line()
    {
        Vector3 spawnPosition = new Vector3(spawnPositionLeft.position.x, spawnPositionLeft.position.y + 13, spawnPositionLeft.position.z);
        for (int i = 0; i < sizeOfHazards; i++)
        {
            if (i == Line4Spacing || i == Line4Spacing + 1 || i == Line4Spacing + 2)
            {
                spawnPosition.x += marginX;
            }
            else
            {
                Instantiate(hazardRight, spawnPosition, spawnPositionRight.rotation);
                spawnPosition.x += marginX;
            }
        }
        spawnPosition.x = spawnPosition.x + 0.2F;
        Instantiate(boundary, spawnPosition, spawnPositionRight.rotation);
    }
}
