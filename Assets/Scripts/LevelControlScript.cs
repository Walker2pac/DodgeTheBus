using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {

	public static LevelControlScript instance = null;
	GameObject levelSign, gameOverText, youWinText;
	int sceneIndex, levelPassed;

	void Start () {
		
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
	}

	public void youWin()
	{
		if (sceneIndex == 3)
			Invoke ("loadMainMenu", 1f);
		else {
			if (levelPassed < sceneIndex)
				PlayerPrefs.SetInt ("LevelPassed", sceneIndex);
			/*levelSign.gameObject.SetActive (false);
			youWinText.gameObject.SetActive (true);*/
			Invoke ("loadNextLevel", 1f);
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
