using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	void Start () {
		
	}
    
    public void StartGame()
    {
        Application.LoadLevel(1);
    }
    public void Settings()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}
