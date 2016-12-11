using UnityEngine;
using System.Collections.Generic;

public class InventoryControllerScript : MonoBehaviour
{
	public Transform selectedSlot, selectedItem;
	public GameObject slotPrefab, itemPrefab, scrollContent;
	public Vector2 windowSize;
	public Vector2 inventorySize;
	public float slotSize;

	void Awake()
	{
		inventorySize = new Vector2(8, 1);
	}

	// Use this for initialization
	void Start ()
	{
		for(int x=1; x<=inventorySize.x; x++)
		{
			for(int y=1; y<=inventorySize.y; y++)
			{
				GameObject slot = Instantiate(slotPrefab) as GameObject;
				slot.transform.parent = scrollContent.transform;
				slot.name = "slot X_"+x+" Y_"+y;
				//slot.GetComponent<RectTransform>().anchoredPosition = new Vector3((windowSize.x/((inventorySize.x/2)+0.25f)*x)-220, (windowSize.y/(inventorySize.y+0.2f)*-y)+215, 0);
				slot.transform.localScale = new Vector3(1,1,1);
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
}
