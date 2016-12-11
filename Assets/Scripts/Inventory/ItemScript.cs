using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{
	public string itemName;
	public int itemCost;

	public Sprite itemImage;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SelectItem()
	{
		transform.parent.parent.parent.parent.GetComponent<InventoryControllerScript>().selectedItem = this.transform;
	}
}
