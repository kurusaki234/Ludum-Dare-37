using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryControllerScript : MonoBehaviour
{
	public GameObject[] inventorySlotArray;
	public GameObject[] shopSlotArray;
	public int inventorySize;
	public int shopSize;

	public GameObject slotPrefab, itemPrefab, scrollContent;
	public Transform selectedItem;

	void Awake()
	{
		if(transform.GetComponent<InventoryControllerScript>().gameObject.name == "Inventory")
		{
			inventorySize = 8;
			inventorySlotArray = new GameObject[inventorySize];
		}
		else
		{
			shopSize = 8;
			shopSlotArray = new GameObject[shopSize];
		}
	}

	// Use this for initialization
	void Start ()
	{
		if(transform.GetComponent<InventoryControllerScript>().gameObject.name == "Inventory")
		{
			for(int i=0; i<inventorySlotArray.Length; i++)
			{
				inventorySlotArray[i] = Instantiate(slotPrefab) as GameObject;
				inventorySlotArray[i].transform.parent = scrollContent.transform;
				inventorySlotArray[i].name = "inventorySlot_"+i;
				inventorySlotArray[i].transform.localScale = new Vector3(1,1,1);
			}
		}
		else
		{
			for(int i=0; i<shopSlotArray.Length; i++)
			{
				shopSlotArray[i] = Instantiate(slotPrefab) as GameObject;
				shopSlotArray[i].transform.parent = scrollContent.transform;
				shopSlotArray[i].name = "shopSlot_"+i;
				shopSlotArray[i].transform.localScale = new Vector3(1,1,1);


				if(i < GameDatabaseScript.itemList.Count)
				{
					GameObject item = Instantiate(itemPrefab) as GameObject;
					item.transform.parent = shopSlotArray[i].transform;
					item.transform.localScale = new Vector3(1,1,1);
					item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
					ItemScript it = item.GetComponent<ItemScript>();

					// Item Component Variable
					it.itemName = GameDatabaseScript.itemList[i].itemName;
					it.itemCost = GameDatabaseScript.itemList[i].itemCost;
					it.itemImage = GameDatabaseScript.itemList[i].itemImage;

					item.name = it.itemName;
					item.GetComponent<Image>().sprite = it.itemImage;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(selectedItem != null)
		{
			// Enable button for sell, use item : for eg, selectedItem.Use
		}
	}

	public void BuyItem()
	{
		for(int i=0; i<inventorySlotArray.Length; i++)
		{
			if(inventorySlotArray[i].transform.childCount == 0)
			{

			}
		}
	}

	public void SellItem()
	{

	}

	public void UseItem()
	{

	}
}
