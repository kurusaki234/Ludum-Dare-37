using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDatabaseScript : MonoBehaviour
{
	public Sprite[] sprites;

	public static List<ItemScript> itemList = new List<ItemScript>();

	// Use this for initialization
	void Start ()
	{
		// Creating item
		ItemScript itemA = new ItemScript();
		itemA.itemName = "itemA";
		itemA.itemCost = 1;
		itemA.itemImage = sprites[0];
		itemList.Add(itemA);

		// Creating item
		ItemScript itemB = new ItemScript();
		itemB.itemName = "itemB";
		itemB.itemCost = 2;
		itemB.itemImage = sprites[1];
		itemList.Add(itemB);

		// Creating item
		ItemScript itemC = new ItemScript();
		itemC.itemName = "itemC";
		itemC.itemCost = 3;
		itemC.itemImage = sprites[2];
		itemList.Add(itemC);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
