using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHazards : MonoBehaviour {

    public Transform hazardSpawn;
    public Hazard hazard;
	public HazardRight hazardRight;

    //public float maxLines;
    public Vector2 firstLineHazards;
    public Vector2 secondLineHazards;
    public Vector2 thirdLineHazards;
    public Vector2 fourthLineHazards;
    public Vector2 fifthLineHazards;
    public Vector2 sixthLineHazards;
    public Vector2 seventhLineHazards;
    public int sizeOfHazards;

    private Vector3[] arrayOfHazards;

    public float marginX;
    public float marginY;
	public float spawnPositionXRight;
	public float spawnPositionXLeft;
    public int numberOfLines;
    private bool changeLine;
    private bool stopSpawn;

	void Start () 
    {
        arrayOfHazards = new Vector3[numberOfLines];
        changeLine = false;
        stopSpawn = false;
        //Spawn();
        FillArrayOfHazards();
	}

    void FillArrayOfHazards()
    {
        Vector3 spawnPosition = new Vector3(hazardSpawn.position.x, hazardSpawn.position.y, hazardSpawn.position.z);
        for (int i = 0; i < arrayOfHazards.Length; i++ )
        {
            int spaceInHazards = (int)Random.Range(1.0F, sizeOfHazards);
            for(int j = 0; j < sizeOfHazards; j++)
            {   
                if(j == spaceInHazards || j == spaceInHazards + 1 || j == spaceInHazards + 2)
                {
                    stopSpawn = true;
                }

                if (changeLine == false && stopSpawn == false)
                {
                    Instantiate(hazard, spawnPosition, hazardSpawn.rotation);
                    spawnPosition.x -= marginX;
                }
                if (changeLine == true && stopSpawn == false)
                {
                    Instantiate(hazardRight, spawnPosition, hazardSpawn.rotation);
                    spawnPosition.x += marginX;
                }              
                
                stopSpawn = false;
            }
            //переводит курсор влево
            if (changeLine == false)
            {
                spawnPosition.x = spawnPositionXLeft;
                spawnPosition.y += marginY;
                changeLine = true;
            }
            //переводит курсор вправо
            else if(changeLine == true)
            {
                spawnPosition.x = spawnPositionXRight;
                spawnPosition.y += marginY;
                changeLine = false;
            }


        }
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(hazardSpawn.position.x, hazardSpawn.position.y, hazardSpawn.position.z);
        //////////////////////////////////////////////
        //Первая линия(отсчет снизу)
        for (int i = 0; i < firstLineHazards.x; i++)
        {
            if(i == firstLineHazards.y || i == firstLineHazards.y + 1 || i == firstLineHazards.y + 2) 
            {
                spawnPosition.x -= marginX;
            }
            else 
            {
                Instantiate(hazard, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x -= marginX;
            }

        }
        spawnPosition.x = spawnPositionXLeft;
        spawnPosition.y += marginY;
        //////////////////////////////////////////////
        //Вторая линия(отсчет снизу)
        for (int i = 0; i < secondLineHazards.x; i++)
        {
            if (i == secondLineHazards.y || i == secondLineHazards.y + 1 || i == secondLineHazards.y + 2)
            {
                spawnPosition.x += marginX;
            }
            else
            {
                Instantiate(hazardRight, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x += marginX;
            }
        }
        spawnPosition.x = spawnPositionXRight;
        spawnPosition.y += marginY;
        //////////////////////////////////////////////
        //Третья линия(отсчет снизу)
        for (int i = 0; i < thirdLineHazards.x; i++)
        {
            if (i == thirdLineHazards.y || i == thirdLineHazards.y + 1 || i == thirdLineHazards.y + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x -= marginX;
            }
        }
        spawnPosition.x = spawnPositionXLeft;
        spawnPosition.y += marginY;
        //////////////////////////////////////////////
        //Четвертая линия(отсчет снизу)
        for (int i = 0; i < fourthLineHazards.x; i++)
        {
            if (i == fourthLineHazards.y || i == fourthLineHazards.y + 1 || i == fourthLineHazards.y + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazardRight, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x += marginX;
            }
        }
        spawnPosition.x = spawnPositionXRight;
        spawnPosition.y += marginY;
        //////////////////////////////////////////////
        //Пятая линия(отсчет снизу)
        for (int i = 0; i < fifthLineHazards.x; i++)
        {
            if (i == fifthLineHazards.y || i == fifthLineHazards.y + 1 || i == fifthLineHazards.y + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x -= marginX;
            }
        }
        spawnPosition.x = spawnPositionXLeft;
        spawnPosition.y += marginY;
        //////////////////////////////////////////////
        //Шестая линия(отсчет снизу)
        for (int i = 0; i < sixthLineHazards.x; i++)
        {
            if (i == sixthLineHazards.y || i == sixthLineHazards.y + 1 || i == sixthLineHazards.y + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazardRight, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x += marginX;
            }
        }
        spawnPosition.x = spawnPositionXRight;
        spawnPosition.y += marginY;
        //////////////////////////////////////////////
        //Седьмая линия(отсчет снизу)
        for (int i = 0; i < seventhLineHazards.x; i++)
        {
            if (i == seventhLineHazards.y || i == seventhLineHazards.y + 1 || i == seventhLineHazards.y + 2)
            {
                spawnPosition.x -= marginX;
            }
            else
            {
                Instantiate(hazard, spawnPosition, hazardSpawn.rotation);
                spawnPosition.x -= marginX;
            }
        }
           
    }
}