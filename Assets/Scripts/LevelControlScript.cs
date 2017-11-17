using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

	public static LevelControlScript instance = null;
	int sceneIndex, levelPassed;

	void Start () {
		
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
	}

	public void goToNextLevel()
	{
		if (sceneIndex == 3)
			Invoke ("loadMainMenu", 1f);
		else {
			if (levelPassed < sceneIndex)
				PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
			Invoke ("loadNextLevel", 0.2f);
		}
	}

	public void youLose()
	{
        Invoke("loadMainMenu", 1F);
	}

	void loadNextLevel()
	{
		SceneManager.LoadScene (sceneIndex + 1);
	}

	void loadMainMenu()
	{
		SceneManager.LoadScene ("LevelMenu");
	}
}
