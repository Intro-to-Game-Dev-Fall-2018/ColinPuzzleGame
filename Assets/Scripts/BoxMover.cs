using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class BoxMover : MonoBehaviour
{


	private enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}

	private bool canMove = true, moving = false;
	private int speed = 5, buttonCooldown = 0;
	private Direction dir = Direction.Down;
	private Vector3Int pos;
	public Tilemap Tilemap;
	private Direction PlayerDirection;
	private bool PlayerTouching = false;
	public int score = 0;
	private bool PlayerMovingBox = false;

	// Use this for initialization
	void Start()
	{
		transform.position = Vector3Int.RoundToInt(transform.position);
		pos = Vector3Int.RoundToInt(transform.position);
		score = GameObject.Find("goal").GetComponent<GoalScript>().score;

	}

	// Update is called once per frame
	void Update()
	{

		if (score == 3)
		{
			SceneManager.LoadScene("scene2");
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			score = score + 1;
		}

		if (Input.GetKeyDown(KeyCode.W))
		{
			PlayerDirection = Direction.Up;
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			PlayerDirection = Direction.Right;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			PlayerDirection = Direction.Down;
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			PlayerDirection = Direction.Left;
		}

		if (GameObject.Find("Player").GetComponent<Movement>().PlayerPos == transform.position)
		{
			if (PlayerTouching == true)
			{
				canMove = true;
				move();
			}

			if (moving)
			{
				if (Tilemap.HasTile(pos) == true)
				{
					canMove = false;
					pos = Vector3Int.RoundToInt(transform.position);
					Debug.Log("Has tile");
				}

				if (transform.position == pos)
				{
					moving = false;
					canMove = true;
					//PlayerTouching = false;
				}

				transform.position = Vector3.MoveTowards(transform.position, pos, 1);
				Debug.Log(pos);
			}

		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerTouching = true;
			Debug.Log("Touching");
		}

		if (other.gameObject.CompareTag("goal"))
		{
			score = score + 1;
		}
	}


	private void move()
	{
		if (PlayerTouching == true)
		{
			

			if (buttonCooldown <= 0)
			{
				if (PlayerDirection == Direction.Up)
				{

					if (dir != Direction.Up)
					{
						dir = Direction.Up;
					}
					else

					{
						canMove = false;
						moving = true;
						pos += Vector3Int.up;
						PlayerTouching = false;
					}
				}

				else if (PlayerDirection == Direction.Left)
				{
					{
						if (dir != Direction.Left)
						{
							dir = Direction.Left;
						}
						else
						{
							canMove = false;
							moving = true;
							pos += Vector3Int.left;
							PlayerTouching = false;

						}
					}
				}

				else
				{
					if (PlayerDirection == Direction.Right)
					{
						if (dir != Direction.Right)
						{
							dir = Direction.Right;
						}
						else
						{
							canMove = false;
							moving = true;
							pos += Vector3Int.right;
							PlayerTouching = false;
						}
					}
				}

				 if(PlayerDirection == Direction.Down)
				{
							if (PlayerDirection == Direction.Down)
							{
								if (dir != Direction.Down)
								{
									dir = Direction.Down;
								}
								else
								{
									canMove = false;
									moving = true;
									pos += Vector3Int.down;
									PlayerTouching = false;
								}

							}
						}
					}
				}
			}
		}

