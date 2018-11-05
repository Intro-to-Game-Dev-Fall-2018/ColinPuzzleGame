using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
	public int score;
	public Vector3[] goalPositionsArray;
	public Vector3 BoxPosition;
	public AudioSource audioclip;

	// Use this for initialization
	void Start ()
	{
		score = (GameObject.Find("Box").GetComponent<BoxMover>().score);
		BoxPosition = (GameObject.Find("Box").GetComponent<Transform>().position);
		audioclip = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		if ((score == 3))
		{
			SceneManager.LoadScene("scene2");
		}

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Box"))
		{
			foreach (var Vector3 in goalPositionsArray)
			{
				if (BoxPosition == Vector3)
				{
					score = score + 1;
					audioclip.Play();
				}
			}

			Debug.Log(score);
		}
	}
}
