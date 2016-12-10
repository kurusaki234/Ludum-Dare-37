using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Player
{
	public class Movement : MonoBehaviour 
	{
		public int rowIndex;
		public int colIndex;
		public int targetRowIndex;
		public int targetColIndex;

		public int moveGridIndex = 0;
		public List<Vector3> moveGridList = new List<Vector3>();

		Vector3 currentGridPos;
		float moveGridTimer = 0.0f;
		public float moveGridDuration;

		bool moveVertical = false;
		bool moveLeft = false;
		bool moveUp = false;
		bool reverse = false;

		void Start()
		{
			transform.position = new Vector3(-12.0f, 0.5f, 8.0f);
			rowIndex = 0;
			colIndex = 0;
		}

		void Update()
		{
			if(moveGridIndex < moveGridList.Count)
			{
				moveGridTimer += Time.deltaTime;
				transform.position = Vector3.Lerp(currentGridPos,moveGridList[moveGridIndex], moveGridTimer/moveGridDuration);

				if(moveGridTimer >= moveGridDuration)
				{
					currentGridPos = transform.position;
					moveGridTimer = 0.0f;
					moveGridIndex++;
				}
				if(moveGridIndex >= moveGridList.Count)
				{
					moveGridIndex = 0;
					moveGridList.Clear();
					rowIndex = targetRowIndex;
					colIndex = targetColIndex;
				}
			}

			if(Input.GetKeyDown(KeyCode.A))
			{
				Move();
			}
		}

		void ReverseMode()
		{
			reverse = !reverse;

			if(!moveVertical)
			{
				moveLeft = !moveLeft;
			}
			else
			{
				moveUp = !moveUp;
			}
		}

		void Move()
		{
			int numMove = Random.Range(1, 7);
			int countMove = 0;
			Debug.Log("Number of Moves: " + numMove);

			while(countMove < numMove)
			{
				if(!reverse)
				{
					if(!moveVertical)
					{
						if(!moveLeft)
						{
							if(targetColIndex + 1 < TileManagerScript.Instance.colCount)
							{
								targetColIndex ++;
								countMove ++;
							}
							else
							{
								moveVertical = true;
								moveUp = false;
							}
						}
						else
						{
							if(targetColIndex - 1 >= 0)
							{
								targetColIndex --;
								countMove ++;
							}
							else
							{
								moveVertical = true;
								moveUp = true;
							}
						}
					}
					else
					{
						if(!moveUp)
						{
							if(targetRowIndex + 1 < TileManagerScript.Instance.rowCount)
							{
								targetRowIndex ++;
								countMove ++;
							}
							else
							{
								moveVertical = false;
								moveLeft = true;
							}
						}
						else
						{
							if(targetRowIndex - 1 >= 0)
							{
								targetRowIndex --;
								countMove ++;
							}
							else
							{
								moveVertical = false;
								moveLeft = false;
							}
						}
					}
				}
				else
				{
					if(!moveVertical)
					{
						if(!moveLeft)
						{
							if(targetColIndex + 1 < TileManagerScript.Instance.colCount)
							{
								targetColIndex ++;
								countMove ++;
							}
							else
							{
								moveVertical = true;
								moveUp = true;
							}
						}
						else
						{
							if(targetColIndex - 1 >= 0)
							{
								targetColIndex --;
								countMove ++;
							}
							else
							{
								moveVertical = true;
								moveUp = false;
							}
						}
					}
					else
					{
						if(!moveUp)
						{
							if(targetRowIndex + 1 < TileManagerScript.Instance.rowCount)
							{
								targetRowIndex ++;
								countMove ++;
							}
							else
							{
								moveVertical = false;
								moveLeft = false;
							}
						}
						else
						{
							if(targetRowIndex - 1 >= 0)
							{
								targetRowIndex --;
								countMove ++;
							}
							else
							{
								moveVertical = false;
								moveLeft = true;
							}
						}
					}
				}
			}

			currentGridPos = transform.position;
			TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
		}
	}
}
