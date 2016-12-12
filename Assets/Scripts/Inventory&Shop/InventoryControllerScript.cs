using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryControllerScript : MonoBehaviour
{
	private static InventoryControllerScript mInstance;

	public static InventoryControllerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("Inventory");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_Inventory");
					mInstance = obj.AddComponent<InventoryControllerScript>();
					obj.tag = "Inventory";
				}
				else
				{
					mInstance = tempObject.GetComponent<InventoryControllerScript >();
				}
			}
			return mInstance;
		}
	}

	public GameObject[] inventorySlotArray;
	public GameObject[] shopSlotArray;
	public int inventorySize;
	public int shopSize;

	public GameObject slotPrefab, itemPrefab, inventoryScrollContent, shopScrollContent;
	public Transform selectedInventoryItem, selectedShopItem;

	void Awake()
	{
		if(transform.FindChild("InventoryScrollPanel"))
		{
			inventorySize = 8;
			inventorySlotArray = new GameObject[inventorySize];
		}
		if(transform.FindChild("ShopScrollPanel"))
		{
			shopSize = 8;
			shopSlotArray = new GameObject[shopSize];
		}
	}

	// Use this for initialization
	void Start ()
	{
		if(transform.FindChild("InventoryScrollPanel"))
		{
			for(int i=0; i<inventorySlotArray.Length; i++)
			{
				inventorySlotArray[i] = Instantiate(slotPrefab) as GameObject;
				inventorySlotArray[i].transform.parent = inventoryScrollContent.transform;
				inventorySlotArray[i].name = "inventorySlot_"+i;
				inventorySlotArray[i].transform.localScale = new Vector3(1,1,1);
			}
		}
		if(transform.FindChild("ShopScrollPanel"))
		{
			for(int i=0; i<shopSlotArray.Length; i++)
			{
				shopSlotArray[i] = Instantiate(slotPrefab) as GameObject;
				shopSlotArray[i].transform.parent = shopScrollContent.transform;
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
				else
				{
					Debug.Log("Shop is full, expand the shop size Mr.Developer!");
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void BuyItem()
	{
		if(selectedShopItem != null)
		{
			Debug.Log("Found selected item, proceed to check if there's space...");
			for(int i=0; i<inventorySlotArray.Length; i++)
			{
				Debug.Log("Checking inventory..." + i);
				if(inventorySlotArray[i].gameObject.transform.FindChild(selectedShopItem.name))
				{
					Debug.Log("Bought an item!");
					inventorySlotArray[i].gameObject.transform.GetComponentInChildren<ItemScript>().IncreaseAmount(1);
					break;
				}
				else if(inventorySlotArray[i].gameObject.transform.childCount == 0)
				{
					Debug.Log("Bought an item!");
					GameObject item = Instantiate(itemPrefab) as GameObject;
					item.transform.parent = inventorySlotArray[i].transform;
					item.transform.localScale = new Vector3(1,1,1);
					item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
					ItemScript it = item.GetComponent<ItemScript>();

					// Item Component Variable
					it.itemName = selectedShopItem.GetComponent<ItemScript>().itemName;
					it.itemCost = selectedShopItem.GetComponent<ItemScript>().itemCost;
					it.itemImage = selectedShopItem.GetComponent<ItemScript>().itemImage;

					item.name = it.itemName;
					item.GetComponent<Image>().sprite = it.itemImage;
					item.GetComponent<ItemScript>().IncreaseAmount(0);

					break;
				}
				else
				{
					Debug.Log("Inventory no more space!");
				}
			}
		}
		else
		{
			Debug.Log("No item selected!");
		}
	}

	public void SellItem()
	{
		if(selectedInventoryItem != null)
		{
			for(int i=0; i<inventorySlotArray.Length; i++)
			{
				if(inventorySlotArray[i].gameObject.transform.childCount != 0)
				{
					if(inventorySlotArray[i].gameObject.transform.GetComponentInChildren<ItemScript>().amount >= 2)
					{
						inventorySlotArray[i].gameObject.transform.GetComponentInChildren<ItemScript>().DecreaseAmount(1);
						break;
					}
					else
					{
						Destroy(inventorySlotArray[i].gameObject.transform.GetComponentInChildren<ItemScript>().gameObject);
						break;
					}
				}
				else
				{
					Debug.Log("No item in inventory.");
				}
			}
		}
		else
		{
			Debug.Log("No item selected!");
		}
	}

	public void UseItem()
	{

	}
}
