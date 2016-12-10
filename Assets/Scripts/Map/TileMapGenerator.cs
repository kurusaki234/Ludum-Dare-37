using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[ExecuteInEditMode]
public class TileMapGenerator : MonoBehaviour 
{
	const int mapX = 24;
	const int mapY = 16;
	int[,] mapArray;

	[Serializable]
	public class TileType
	{
		public enum Type
		{
			None = 0,
			Walkable_Tile = 1,
			Unwalkable_Tile = 2,
			Props = 3,
			Event_Tile = 4,
			Fortune_Tile = 5,
			Unfortune_Tile = 6,
			Building_Tile = 7,
			Prison_Tile = 8,

			TOTAL
		};

		public Type tileType = Type.None;

		public string tileName;
		public int level;
		public float currency;
		public GameObject tilePrefab;
	}

	GameObject tileMapPrefab;
	public List <TileType> tileInfo = new List <TileType>();

	void Awake()
	{
		tileMapPrefab = (GameObject)Resources.Load ("Prefabs/TileMap Group");
	}

	void Start()
	{
	}

	[ContextMenu ("Initialize Map")]
	void Initialization()
	{
		InitializeMap();

		GameObject TileMapGroup = (GameObject) Instantiate (tileMapPrefab, this.transform.position, Quaternion.identity);

		for (int i = 0; i < mapY; i++)
		{
			for (int j = 0; j < mapX; j++)
			{
				if (mapArray[i,j] == 0)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[0].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 1)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[1].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 2)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[2].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 3)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[3].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 4)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[4].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 5)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[5].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 6)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[6].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 7)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[7].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 8)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[8].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
				else if(mapArray[i,j] == 9)
				{
					GameObject tile = (GameObject) Instantiate (tileInfo[9].tilePrefab, new Vector3 (i, 0, j), Quaternion.identity);
					tile.transform.parent = TileMapGroup.transform;
				}
			}
		}
	}
	void InitializeMap()
	{
		mapArray = new int[mapY,mapX ] 
		{
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
			{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		};
	}
}
