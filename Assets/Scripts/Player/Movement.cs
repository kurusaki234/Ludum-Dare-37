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
		//float moveGridTimer = 0.0f;
		//public float moveGridDuration;

		public bool bot = true;

		public int moveCount = 0;
		public int numberOfMoves = 0;
		public GameObject targetTile;
		bool canMove = false;
		float distanceTraveled = 0.0f;
		Quaternion tempRotation;

		public LayerMask ground;

		void Start()
		{
			moveCount = 0;
			targetTile = null;
		}

		void Update()
		{
			/*if(moveGridIndex < moveGridList.Count)
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
					Debug.Log("rowDifference: " + (targetRowIndex - rowIndex) + "\tcolDifference: " + (targetColIndex - colIndex));
					rowIndex = targetRowIndex;
					colIndex = targetColIndex;
					transform.eulerAngles = tempRotation.eulerAngles;

					//GameManager.Instance.NextTurn();
				}

				//GameManager.Instance.CameraFollow();
			}
*/

			if(Input.GetKeyDown(KeyCode.A))
			{
				if(moveCount != 0)
				{
					moveCount = 0;
				}

				//numberOfMoves = Random.Range(1, 7);
				numberOfMoves = 6;
				canMove = true;
			}

			if(canMove)
			{
				if(moveCount < numberOfMoves)
				{
					Vector3 oldPos = transform.position;
					transform.position = Vector3.Lerp(transform.position, (transform.position + transform.forward), Time.deltaTime);
					distanceTraveled += Vector3.Distance(oldPos, transform.position);

					if(distanceTraveled >= 1.0f)
					{
						//Debug.Log("x:" + transform.position.x + "\ty:" + transform.position.y + "\tz:" + transform.position.z);
						distanceTraveled = 0;
						moveCount ++;
					}
				}
				else
				{
					RaycastHit hitInfo;

					if (Physics.Raycast (this.transform.position, Vector3.down, out hitInfo, ground))
					{
						if (targetTile == null)
						{
							targetTile = hitInfo.transform.gameObject;
							transform.position = new Vector3(targetTile.transform.position.x, 0.0f, targetTile.transform.position.z);
							targetTile = null;
						}
					}

					moveCount = 0;
					canMove = false;					
				}
			}
		}

		/*public void Move()
		{
			int numMove = 6;
			int countMove = 0;
			targetColIndex = colIndex;
			targetRowIndex = rowIndex;
			tempRotation = Quaternion.Euler(transform.localEulerAngles);
			//tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);

			while(countMove < numMove)
			{
				if(tempRotation.eulerAngles.y == 90.0f)
				{
					if(rowIndex < TileManagerScript.Instance.rowCount/2)
					{
						// Above path
						if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == false &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 2, targetColIndex) == true && 
									TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex  + 2) == true)
								{
									int rand = Random.Range(1, 3);

									switch(rand)
									{
									case 1:
										targetColIndex++;
										break;

									case 2:
										targetRowIndex ++;
										tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
										break;
									}
								}
								else
								{
									targetColIndex++;
								}
							}
							else
							{
								targetRowIndex ++;
								tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == false)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
								{
									targetRowIndex ++;
									tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
								}
								else
								{
									targetColIndex ++;
								}
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 2) == true)
							{
								int rand = Random.Range(1, 3);

								switch(rand)
								{
								case 1:
									targetColIndex ++;
									break;

								case 2:
									targetRowIndex ++;
									tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
									break;
								}								
							}
							else
							{
								targetRowIndex ++;
								tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == false &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == false)
						{
							targetColIndex++;
						}
					}
					else
					{
						// Bottom
						if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == false)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 2, targetColIndex) == true &&
									TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 2) == true)
								{
									int rand = Random.Range(1, 3);

									switch(rand)
									{
									case 1:
										targetColIndex ++;
										break;

									case 2:
										targetRowIndex --;
										tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
										break;
									}
								}
								else
								{
									targetColIndex ++;
								}
							}
							else
							{
								targetRowIndex --;
								tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == false &&
								TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true)
								{
									targetRowIndex --;
									tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
								}
								else
								{
									targetColIndex++;
								}
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
								TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex + 2) == true)
							{
								int rand = Random.Range(1, 3);

								switch(rand)
								{
								case 1:
									targetColIndex ++;
									break;

								case 2:
									targetRowIndex --;
									tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
									break;
								}								
							}
							else
							{
								targetRowIndex --;
								tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
							}
						}
					}
				}
				else if(tempRotation.eulerAngles.y == 270.0f)
				{
					if(rowIndex < TileManagerScript.Instance.rowCount/2)
					{
						// Above path
						if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == false &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 2, targetColIndex) == true && 
									TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex  - 2) == true)
								{
									int rand = Random.Range(1, 3);

									switch(rand)
									{
									case 1:
										targetColIndex--;
										break;

									case 2:
										targetRowIndex ++;
										tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
										break;
									}
								}
								else
								{
									targetColIndex--;
								}
							}
							else
							{
								targetRowIndex ++;
								tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == false)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
								{
									targetRowIndex ++;
									tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
								}
								else
								{
									targetColIndex --;
								}
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 2) == true)
							{
								int rand = Random.Range(1, 3);

								switch(rand)
								{
								case 1:
									targetColIndex --;
									break;

								case 2:
									targetRowIndex ++;
									tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
									break;
								}								
							}
							else
							{
								targetRowIndex ++;
								tempRotation.eulerAngles = new  Vector3(0.0f, 180.0f, 0.0f);
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == false &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == false)
						{
							targetColIndex--;
						}
					}
					else
					{
						// Bottom
						if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == false)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 2, targetColIndex) == true &&
									TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 2) == true)
								{
									int rand = Random.Range(1, 3);

									switch(rand)
									{
									case 1:
										targetColIndex --;
										break;

									case 2:
										targetRowIndex --;
										tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
										break;
									}
								}
								else
								{
									targetColIndex --;
								}
							}
							else
							{
								targetRowIndex --;
								tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == false &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 1) == true)
							{
								if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true)
								{
									targetRowIndex --;
									tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
								}
								else
								{
									targetColIndex--;
								}
							}
						}
						else if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex - 1, targetColIndex) == true &&
							TileManagerScript.Instance.CheckWalkableTile(targetRowIndex + 1, targetColIndex) == true)
						{
							if(TileManagerScript.Instance.CheckWalkableTile(targetRowIndex, targetColIndex - 2) == true)
							{
								int rand = Random.Range(1, 3);

								switch(rand)
								{
								case 1:
									targetColIndex --;
									break;

								case 2:
									targetRowIndex --;
									tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
									break;
								}								
							}
							else
							{
								targetRowIndex --;
								tempRotation.eulerAngles = new  Vector3(0.0f, 0.0f, 0.0f);
							}
						}
					}
				}

				countMove ++;
			}

			currentGridPos = transform.position;
			TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
	}*/

		void OnTriggerEnter(Collider other)
		{
			if(other.CompareTag("Chances"))
			{
				if(transform.localEulerAngles.y == 90.0f || transform.localEulerAngles.y == 270.0f)
				{
					if(transform.position.x > -15 && transform.position.x < 14)
					{
						if(transform.position.z < 0)
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
								break;
							}
						}
						else
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
								break;
							}
						}
					}
					else
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 2:
							transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;
						}
					}
				}
				else if(transform.localEulerAngles.y == 180.0f || transform.localEulerAngles.y == 0.0f)
				{
					if(transform.position.x > -15 && transform.position.x < 14)
					{
						int rand = Random.Range(1, 4);

						switch(rand)
						{
						case 1:
							transform.localEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;

						case 2:
							transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;
						}
					}
					else
					{
						if(transform.position.x < 0)
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
								break;
							}
						}
						else
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
								break;
							}
						}
					}
				}
			}
			else if(other.CompareTag("Corner"))
			{
				if(transform.localEulerAngles.y == 90.0f || transform.localEulerAngles.y == 270.0f || transform.localEulerAngles.y == -90.0f)
				{
					if((int)transform.position.z < 0)
					{
						transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
					}
					else
					{
						transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
					}
				}
				else if(transform.localEulerAngles.y == 180.0f || transform.localEulerAngles.y == 0.0f)
				{
					if((int)transform.position.x < 0)
					{
						transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
					}
					else
					{
						transform.localEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
					}
				}
			}
			else if(other.CompareTag("Inner"))
			{
				if(transform.localEulerAngles.y == 90.0f || transform.localEulerAngles.y == 270.0f || transform.localEulerAngles.y == -90.0f)
				{
					if(transform.position.x > - 2 && transform.position.x < 1)
					{
						if(transform.position.z < 0)
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
								break;
							}
						}
						else
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
								break;
							}
						}
					}
					else
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 2:
							transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;
						}
					}
				}
				else if(transform.localEulerAngles.y == 180.0f || transform.localEulerAngles.y == 0.0f)
				{
					if(transform.position.x > - 2 && transform.position.x < 1)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;

						case 2:
							transform.localEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;
						}
					}
					else
					{
						if(transform.position.x < 0)
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
								break;
							}
						}
						else
						{
							int rand = Random.Range(1, 3);

							switch(rand)
							{
							case 1:
								transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
								break;
							}
						}
					}
				}
			}
		}
	}
}
