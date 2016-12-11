using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemScript : MonoBehaviour
{
	public string itemName;
	public int itemCost, amount;

	public Sprite itemImage;

	void Awake()
	{
		amount = 1;
	}

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

	public void IncreaseAmount(int amt)
	{
		amount += amt;
		transform.FindChild("AmountCount").GetComponent<Text>().text = amount.ToString();
	}

	public void DecreaseAmount(int amt)
	{
		if(amount > 1)
		{
			amount -= amt;
			transform.FindChild("AmountCount").GetComponent<Text>().text = amount.ToString();
		}
	}
}
