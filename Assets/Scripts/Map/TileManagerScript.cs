using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TileManagerScript : MonoBehaviour 
{
	private static TileManagerScript mInstance;

	public static TileManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("TileManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_TileManager");
					mInstance = obj.AddComponent<TileManagerScript>();
					obj.tag = "TileManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<TileManagerScript>();
				}
			}
			return mInstance;
		}
	}

	int[,] mapArray;
	const int mapX = 32;
	const int mapY = 24;

	public int rowCount;
	public int colCount;

	public GameObject tilePrefab;

	public List<TileScript> tileList = new List<TileScript>();

	[ContextMenu ("Initialize Map")]
	void Initialization()
	{
		InitializeMap();

		for (int i = 0; i < mapY; i++)
		{
			for (int j = 0; j < mapX; j++)
			{
				TileScript tempTileScript = ((GameObject) Instantiate(tilePrefab, new Vector3(j - colCount/2, -1.0f, rowCount/2 - i), Quaternion.identity)).GetComponent<TileScript>();
				tempTileScript.transform.parent = transform;

				if (mapArray[i,j] == 1)
				{
					tempTileScript.type = TileScript.Type.Walkable_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[0];
				}
				else if (mapArray[i,j] == 2)
				{
					tempTileScript.type = TileScript.Type.Unwalkable_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[1];
				}
				else if (mapArray[i,j] == 3)
				{
					tempTileScript.type = TileScript.Type.Building_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[2];
				}
				else if (mapArray[i,j] == 4)
				{
					tempTileScript.type = TileScript.Type.Shop_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[3];
				}
				else if (mapArray[i,j] == 5)
				{
					tempTileScript.type = TileScript.Type.Event_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[4];
				}
				else if (mapArray[i,j] == 6)
				{
					tempTileScript.type = TileScript.Type.Fortune_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[5];
				}
				else if (mapArray[i,j] == 7)
				{
					tempTileScript.type = TileScript.Type.Unfortune_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[6];
				}
				else if (mapArray[i,j] == 8)
				{
					tempTileScript.type = TileScript.Type.Prison_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[7];
				}
				else if (mapArray[i,j] == 9)
				{
					tempTileScript.type = TileScript.Type.Storage_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[8];
				}
				else if (mapArray[i,j] == 10)
				{
					tempTileScript.type = TileScript.Type.Temple_Tile;
					tempTileScript.meshRenderer.material = tempTileScript.tileMaterials[9];
				}

				tempTileScript.rowIndex = i;
				tempTileScript.colIndex = j;

				tileList.Add(tempTileScript);
			}
		}
	}

	void InitializeMap()
	{
		mapArray = new int[mapY,mapX] 
		{
			{2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 		3, 3, 3, 3, 3, 10, 10, 3, 3, 3,		 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,		3, 3},
			{2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 	1, 1, 1, 1, 6, 5, 5, 7, 1, 1,		 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,		1, 3},
			{2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 	1, 1, 1, 1, 7, 5, 5, 6, 1, 1,		 1, 1, 1, 1, 1, 1, 8, 1, 1, 1,		1, 3},
			{3, 1, 1, 9, 9, 3, 3, 3, 3, 3, 		3, 3, 3, 3, 3, 7, 6, 3, 3, 3,		 3, 3, 3, 3, 3, 3, 2, 4, 4, 1,		1, 3},
			{3, 1, 1, 9, 9, 3, 3, 3, 3, 3, 		3, 3, 3, 3, 3, 1, 1, 3, 3, 3,		 3, 3, 3, 3, 3, 3, 3, 4, 4, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 1, 1, 1, 		1, 1, 1, 1, 1, 6, 7, 1, 1, 1,		 1, 1, 1, 1, 1, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 1, 1, 1, 		1, 1, 1, 1, 1, 6, 7, 1, 1, 1,		 1, 1, 1, 1, 1, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 3, 3, 3, 		3, 3, 3, 3, 3, 1, 1, 3, 3, 3,		 3, 3, 3, 3, 3, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 3, 3, 3, 		3, 3, 3, 3, 3, 1, 1, 3, 3, 3,		 3, 3, 3, 3, 3, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,		 1, 1, 1, 3, 3, 1, 1, 3, 3, 1,		1, 3},
			{3, 7, 6, 3, 3, 1, 1, 3, 3, 1, 		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,		 2, 2, 1, 3, 3, 1, 1, 3, 3, 7,		6, 3},
			{3, 5, 5, 7, 1, 5, 5, 1, 1, 1, 		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,		 2, 2, 1, 1, 1, 5, 5, 1, 6, 5,		5, 3},
			{3, 5, 5, 6, 1, 5, 5, 1, 1, 1, 		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,		 2, 2, 1, 1, 1, 5, 5, 1, 7, 5,		5, 3},
			{3, 7, 6, 3, 3, 1, 1, 3, 3, 1, 		2, 2, 2, 2, 2, 2, 2, 2, 2, 2,		 2, 2, 1, 3, 3, 1, 1, 3, 3, 6,		7, 3},
			{3, 1, 1, 3, 3, 1, 1, 3, 3, 1, 		1, 1, 1, 1, 1, 1, 1, 1, 1, 1,		 1, 1, 1, 3, 3, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 3, 3, 3, 		3, 3, 3, 3, 3, 1, 1, 3, 3, 3,		 3, 3, 3, 3, 3, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 3, 3, 3, 		3, 3, 3, 3, 3, 1, 1, 3, 3, 3,		 3, 3, 3, 3, 3, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 1, 1, 1, 		1, 1, 1, 1, 1, 7, 6, 1, 1, 1,		 1, 1, 1, 1, 1, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 3, 3, 1, 1, 1, 1, 1, 		1, 1, 1, 1, 1, 6, 6, 1, 1, 1,		 1, 1, 1, 1, 1, 1, 1, 3, 3, 1,		1, 3},
			{3, 1, 1, 4, 4, 3, 3, 3, 3, 3, 		3, 3, 3, 3, 3, 1, 1, 3, 3, 3,		 3, 3, 3, 3, 3, 3, 3, 9, 9, 1,		1, 3},
			{3, 1, 1, 4, 4, 3, 3, 3, 3, 3, 		3, 3, 3, 3, 3, 7, 6, 3, 3, 3,		 3, 3, 3, 3, 3, 3, 2, 9, 9, 1,		1, 3},
			{3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 		1, 1, 1, 1, 6, 5, 5, 7, 1, 1,		 1, 1, 1, 1, 1, 1, 8, 1, 1, 1,		1, 3},
			{2, 8, 1, 1, 1, 1, 1, 1, 1, 1, 		1, 1, 1, 1, 7, 5, 5, 6, 1, 1,		 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,		1, 3},
			{2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 		3, 3, 3, 3, 3, 10, 10, 3, 3, 3,		 3, 3, 3, 3, 3, 3, 3, 3, 3, 3,		3, 3},
		};

		rowCount = mapArray.GetLength(0);
		colCount = mapArray.GetLength(1);
	}

	public bool CheckWalkableTile(int row, int col)
	{
		if(row < 0 || row > rowCount ||
			col < 0 || col > colCount)
		{
			return false;
		}

		for(int i = 0; i < tileList.Count; i++)
		{
			if(tileList[i].rowIndex == row && tileList[i].colIndex == col)
			{
				if(tileList[i].type == TileScript.Type.Walkable_Tile ||
					tileList[i].type == TileScript.Type.Event_Tile ||
					tileList[i].type == TileScript.Type.Fortune_Tile ||
					tileList[i].type == TileScript.Type.Unfortune_Tile ||
					tileList[i].type == TileScript.Type.Prison_Tile)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		return false;
	}

	public void GeneratePath(int startRowIndex, int startColIndex, int endRowIndex, int endColIndex, ref List<Vector3> moveGridList)
	{
		if(AStarPathScript.gridMap != null)
		{
			AStarPathScript.gridMap.Clear();
		}
		else
		{
			AStarPathScript.gridMap = new List<List<bool>>();
		}

		for(int i = 0; i < rowCount; i++)
		{
			List<bool> boolList = new List<bool>();

			for(int j = 0; j < colCount; j++)
			{
				boolList.Insert(j, false);
			}
			AStarPathScript.gridMap.Insert(i, boolList);
		}

		for(int i = 0; i < tileList.Count; i++)
		{
			if(tileList[i].type == TileScript.Type.Walkable_Tile ||
				tileList[i].type == TileScript.Type.Event_Tile ||
				tileList[i].type == TileScript.Type.Fortune_Tile ||
				tileList[i].type == TileScript.Type.Unfortune_Tile ||
				tileList[i].type == TileScript.Type.Prison_Tile)
			{
				AStarPathScript.gridMap[tileList[i].rowIndex][tileList[i].colIndex] = true;
			}
		}

		if(AStarPathScript.startIndex == null)
		{
			AStarPathScript.startIndex = new NodeIndex();
		}
		AStarPathScript.startIndex.i = startRowIndex;
		AStarPathScript.startIndex.j = startColIndex;

		if(AStarPathScript.endIndex == null)
		{
			AStarPathScript.endIndex = new NodeIndex();
		}
		AStarPathScript.endIndex.i = endRowIndex;
		AStarPathScript.endIndex.j = endColIndex;

		/*for(int i = 0; i < rowCount; i++)
		{
			List<bool> boolList = new List<bool>();

			for(int j = 0; j < colCount; j++)
			{
				if(map[i,j] == 1)
				{
					boolList.Insert(j, true);
				}
				else if(map[i,j] == 88)
				{
					if(AStarPathScript.startIndex == null)
					{
						AStarPathScript.startIndex = new NodeIndex();
					}
					AStarPathScript.startIndex.i = i;
					AStarPathScript.startIndex.j = j;
					boolList.Insert(j, true);
				}
				else if(map[i,j] == 99)
				{
					if(AStarPathScript.endIndex == null)
					{
						AStarPathScript.endIndex = new NodeIndex();
					}
					AStarPathScript.endIndex.i = i;
					AStarPathScript.endIndex.j = j;
					boolList.Insert(j, true);
				}
				else
				{
					boolList.Insert(j, false);
				}
			}
			AStarPathScript.gridMap.Insert(i, boolList);
		}*/

		AStarPathScript.heuristicType = AStarPathScript.HEURISTIC_METHODS.MANHATTAN;
		AStarPathScript.FindPath();

		if(AStarPathScript.isPathFound)
		{
			for(int i=0; i<AStarPathScript.pathNodes.Count; i++)
			{
				Vector3 nodePos = new Vector3(AStarPathScript.pathNodes[i].nodeIndex.j - colCount/2, 0.0f, rowCount/2 - AStarPathScript.pathNodes[i].nodeIndex.i);

				moveGridList.Add(nodePos);
			}
		}
	}
}
