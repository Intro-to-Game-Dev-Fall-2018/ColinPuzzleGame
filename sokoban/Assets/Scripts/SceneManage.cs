using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
	public int sceneInt;
	public int Score;
	public int ActiveScene;

	// Use this for initialization
	void Start ()
	{
		Score = 0;
		sceneInt = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadScene("scene1");
		}
		if ((sceneInt == 1) && (Score == 3))
		{
			SceneManager.LoadScene("scene2");
			sceneInt = 2;
		}
		
	}
}
