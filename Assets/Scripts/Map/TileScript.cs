﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileScript : MonoBehaviour 
{
	public enum Type
	{
		None = 0,
		Walkable_Tile = 1,
		Unwalkable_Tile = 2,
		Event_Tile = 3,
		Fortune_Tile = 4,
		Unfortune_Tile = 5,
		Building_Tile = 6,
		Prison_Tile = 7,
		Shop_Tile = 8,
		Temple_Tile = 9,
		Storage_Tile = 10,

		TOTAL
	};

	public Type type = Type.None;

	public int rowIndex;
	public int colIndex;

	public MeshRenderer meshRenderer;
	public List<Material> tileMaterials;

	public GameObject[] sadakoBuildings;
	public GameObject[] kayakoBuildings;

	public int currentLevel = 0;
	public GameObject currentBulding = null;

	public void SadokoBuilding(float angleRotate)
	{
		Debug.Log("AAA");
		if(currentLevel == 0)
		{
			 currentBulding = (GameObject)Instantiate(sadakoBuildings[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
				Quaternion.AngleAxis(angleRotate, new Vector3(0.0f, 1.0f, 0.0f)), transform);
			currentLevel ++;
		}
		else if(currentLevel == 1)
		{
			Destroy(currentBulding);

			currentBulding = (GameObject)Instantiate(sadakoBuildings[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
				Quaternion.AngleAxis(angleRotate, new Vector3(0.0f, 1.0f, 0.0f)), transform);
			currentLevel ++;
		}
		else if(currentLevel == 2)
		{
			Destroy(currentBulding);

			currentBulding = (GameObject)Instantiate(sadakoBuildings[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
				Quaternion.AngleAxis(angleRotate, new Vector3(0.0f, 1.0f, 0.0f)), transform);
			currentLevel ++;
		}
		else if(currentLevel == 3)
		{
			Destroy(currentBulding);

			currentBulding = (GameObject)Instantiate(sadakoBuildings[3], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
				Quaternion.AngleAxis(angleRotate, new Vector3(0.0f, 1.0f, 0.0f)), transform);
			currentLevel ++;
		}
	}
}
