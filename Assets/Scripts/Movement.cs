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
	public Vector3Int PlayerPos;
	public Tilemap tilemap;
	public Animator animator;
	

	// Use this for initialization
	void Start()
	{
		transform.position = Vector3Int.RoundToInt(transform.position);
		PlayerPos = Vector3Int.RoundToInt(transform.position);
		animator = GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{

		if (canMove)
		{

			//pos = Vector3Int.FloorToInt(transform.position) ;
			move();
			animator.SetInteger("idle",0);
			transform.position = Vector3Int.RoundToInt(transform.position);
		}

		if (moving)
		{
			if (tilemap.HasTile(PlayerPos) == true)
			{
				canMove = false;
				PlayerPos = Vector3Int.RoundToInt(transform.position);
				Debug.Log("Has tile");
			}
			if (transform.position == PlayerPos)
			{
				moving = false;
				canMove = true;
				move();
			}

			transform.position = Vector3.MoveTowards(transform.position, PlayerPos, Time.deltaTime * speed);
			animator.SetInteger("ninjaWalk",1);
		}

	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Box"))
		{
			canMove = false;
			PlayerPos = Vector3Int.RoundToInt(transform.position);
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
					PlayerPos += Vector3Int.up;
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
						PlayerPos += Vector3Int.left;

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
							PlayerPos += Vector3Int.right;
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
								PlayerPos += Vector3Int.down;
							}

						}
					}
				}
			}
		}
	}
}
