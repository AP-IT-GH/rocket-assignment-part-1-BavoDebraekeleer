using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLoad : MonoBehaviour
{
	public string mLevelToLoad = "";

	// Use this for initialization
	void Start()
	{
		if (mLevelToLoad == "") // default to current scene 
		{
			mLevelToLoad = SceneManager.GetActiveScene().name;
		}
		Debug.Log("LevelToLoad = " + mLevelToLoad);
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(mLevelToLoad);
	}
}
