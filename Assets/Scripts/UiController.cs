using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour {

    private GameObject player;
    private Vector3 playersDefaultPosition;

    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playersDefaultPosition = player.transform.position;
	}

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            restartTheGame();
        }
    }

    public void restartTheGame()
    {
        Debug.Log("restart");
        player.transform.position = playersDefaultPosition;
    }
}
