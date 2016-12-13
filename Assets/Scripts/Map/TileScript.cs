using UnityEngine;
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

	public enum Owner
	{
		None = 0,
		Sadako = 1,
		Kayako = 2,
		Jami = 3,
		DemonFox = 4,

		TOTAL
	}

	public Type type = Type.None;
	public Owner owner = Owner.None;

	public int rowIndex;
	public int colIndex;

	public MeshRenderer meshRenderer;
	public List<Material> tileMaterials;

	public GameObject[] sadakoBuildings;
	public GameObject[] kayakoBuildings;
	public GameObject[] jamiBuildings;
	public GameObject[] demonFoxBuildings;

	public int currentLevel = 0;
	public GameObject currentBulding = null;

	public void SadokoBuilding(float angleRotate)
	{
		if(currentLevel < 3)
		{
			if(currentLevel == 0)
			{
				currentBulding = (GameObject)Instantiate(sadakoBuildings[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)) , transform);
				currentLevel ++;
			}
			else if(currentLevel == 1)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(sadakoBuildings[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 2)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(sadakoBuildings[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
		}
	}

	public void KayakoBuilding(float angleRotate)
	{
		if(currentLevel < 3)
		{
			if(currentLevel == 0)
			{
				currentBulding = (GameObject)Instantiate(kayakoBuildings[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 1)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(kayakoBuildings[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 2)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(kayakoBuildings[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
		}
	}

	public void JamiBuilding(float angleRotate)
	{
		if(currentLevel < 3)
		{
			if(currentLevel == 0)
			{
				currentBulding = (GameObject)Instantiate(jamiBuildings[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 1)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(jamiBuildings[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 2)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(jamiBuildings[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
		}
	}

	public void DemonFoxBuilding(float angleRotate)
	{
		if(currentLevel < 3)
		{
			if(currentLevel == 0)
			{
				currentBulding = (GameObject)Instantiate(demonFoxBuildings[0], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 1)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(demonFoxBuildings[1], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
			else if(currentLevel == 2)
			{
				Destroy(currentBulding);

				currentBulding = (GameObject)Instantiate(demonFoxBuildings[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), 
					Quaternion.AngleAxis (-90.0f, new Vector3 (1.0f, 0.0f, 0.0f)), transform);
				currentLevel ++;
			}
		}
	}
}
