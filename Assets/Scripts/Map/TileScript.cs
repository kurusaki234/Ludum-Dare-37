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
		Starting_Tile = 11,

		TOTAL
	};

	public Type type = Type.None;

	public int rowIndex;
	public int colIndex;

	public MeshRenderer meshRenderer;
	public List<Material> tileMaterials;
}
