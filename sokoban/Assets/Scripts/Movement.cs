using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Direction {Up, Down, Left, Right}

public class Movement : MonoBehaviour
{
	private bool canMove = true, moving = false;
	private int speed = 5, buttonCooldown = 0;
	private Direction dir = Direction.Down;
	private Vector3Int pos;
	public Tilemap tilemap;

	// Use this for initialization
	void Start()
	{
		transform.position = Vector3Int.RoundToInt(transform.position);

	}

	// Update is called once per frame
	void Update()
	{

		if (canMove)
		{

			//pos = Vector3Int.FloorToInt(transform.position) ;
			move();
		}

		if (moving)
		{
			if (tilemap.HasTile(pos) == true)
			{
				canMove = false;
				pos = Vector3Int.RoundToInt(transform.position);
				Debug.Log("Has tile");
			}
			if (transform.position == pos)
			{
				moving = false;
				canMove = true;
				move();
			}

			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		}

	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Box"))
		{
			canMove = false;
			pos = Vector3Int.RoundToInt(transform.position);
		}
	}

	private void move()
	{
		if (buttonCooldown <= 0)
		{
			if (Input.GetKey(KeyCode.W))
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
				}
			}

			else
			{
				if (Input.GetKey((KeyCode.A)))
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

					}
				}

				else
				{
					if (Input.GetKey(KeyCode.D))
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
						}

					}


					else
					{
						if (Input.GetKey(KeyCode.S))
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
							}

						}
					}
				}
			}
		}
	}
}
