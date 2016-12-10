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

		public bool bot = true;

		void Start()
		{
			
		}

		void Update()
		{
			if(moveGridIndex < moveGridList.Count)
			{
				moveGridTimer += Time.deltaTime;
				transform.position = Vector3.Lerp(currentGridPos,moveGridList[moveGridIndex], moveGridTimer/moveGridDuration);

				if(currentGridPos.x > moveGridList[moveGridIndex].x)
				{
					transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
				}
				else if(currentGridPos.x < moveGridList[moveGridIndex].x)
				{
					transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
				}
				else if(currentGridPos.z > moveGridList[moveGridIndex].z)
				{
					transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
				}
				else if(currentGridPos.z < moveGridList[moveGridIndex].z)
				{
					transform.rotation = Quaternion.Euler(Vector3.zero);
				}

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

					GameManager.Instance.NextTurn();
				}

				GameManager.Instance.CameraFollow();
			}
		}

		public void Move()
		{
			int numMove = Random.Range(1, 7);
			int countMove = 0;
			int tempColIndex = colIndex;
			int tempRowIndex = rowIndex;
			Quaternion tempRotation = Quaternion.Euler(transform.localEulerAngles);

			while(countMove < numMove)
			{
				if(tempRotation.eulerAngles.y == 90.0f)
				{
					if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						tempColIndex ++;
						targetColIndex ++;
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						tempRowIndex ++;
						targetRowIndex ++;
						tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						tempRowIndex --;
						targetRowIndex --;
						tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex ++;
							targetRowIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 2:
							tempRowIndex ++;
							targetRowIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 4);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 2:
							tempRowIndex ++;
							targetRowIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;

						case 3:
							tempColIndex ++;
							targetColIndex ++;
							break;
						}
					}
				}
				else if(tempRotation.eulerAngles.y == 180.0f)
				{
					if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						tempRowIndex ++;
						targetRowIndex ++;
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						tempColIndex --;
						targetColIndex --;
						tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						tempColIndex ++;
						targetColIndex ++;
						tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex ++;
							targetRowIndex ++;
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex ++;
							targetRowIndex ++;
							break;

						case 2:
							tempColIndex --;
							targetColIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempColIndex --;
							targetColIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 4);

						switch(rand)
						{
						case 1:
							tempColIndex --;
							targetColIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;

						case 3:
							tempRowIndex ++;
							targetRowIndex ++;
							break;
						}
					}
				}
				else if(tempRotation.eulerAngles.y == 270.0f)
				{
					if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						tempColIndex --;
						targetColIndex --;
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						tempRowIndex --;
						targetRowIndex --;
						tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						tempRowIndex ++;
						targetRowIndex ++;
						tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == false)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 2:
							tempColIndex --;
							targetColIndex --;
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex ++;
							targetRowIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;

						case 2:
							tempColIndex --;
							targetColIndex --;
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex ++;
							targetRowIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;

						case 2:
							tempRowIndex --;
							targetRowIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex + 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 4);

						switch(rand)
						{
						case 1:
							tempRowIndex ++;
							targetRowIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
							break;

						case 2:
							tempRowIndex --;
							targetRowIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
							break;

						case 3:
							tempColIndex --;
							targetColIndex --;
							break;
						}
					}
				}
				else if(tempRotation.eulerAngles.y == 0.0f)
				{
					if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true)
					{
						tempRowIndex --;
						targetRowIndex --;
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false)
					{
						tempColIndex --;
						targetColIndex --;
						tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false)
					{
						tempColIndex ++;
						targetColIndex ++;
						tempRotation.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == false)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempColIndex --;
							targetColIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							break;

						case 2:
							tempColIndex --;
							targetColIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == false &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 3);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;
						}
					}
					else if(TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex + 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex, tempColIndex - 1) == true &&
						TileManagerScript.Instance.CheckWalkableTile(tempRowIndex - 1, tempColIndex) == true)
					{
						int rand = Random.Range(1, 4);

						switch(rand)
						{
						case 1:
							tempRowIndex --;
							targetRowIndex --;
							break;

						case 2:
							tempColIndex ++;
							targetColIndex ++;
							tempRotation.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
							break;

						case 3:
							tempColIndex --;
							targetColIndex --;
							tempRotation.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
							break;
						}
					}
				}

				//Debug.Log(tempRotation.eulerAngles);

				countMove ++;
			}

			currentGridPos = transform.position;
			TileManagerScript.Instance.GeneratePath(rowIndex, colIndex, targetRowIndex, targetColIndex, ref moveGridList);
		}
	}
}
