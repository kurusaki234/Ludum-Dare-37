using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemScript : MonoBehaviour
{
	public Button sellButton, buyButton, useButton;

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
		if(InventoryControllerScript.Instance.selectedInventoryItem != this.transform && InventoryControllerScript.Instance.selectedShopItem != this.transform)
		{
			buyButton.gameObject.SetActive(false);
			useButton.gameObject.SetActive(false);
			sellButton.gameObject.SetActive(false);
		}
	}

	public void SelectItem()
	{
		if(this.transform.parent.parent.name == "InventoryScrollContent")
		{
			transform.parent.parent.parent.parent.GetComponent<InventoryControllerScript>().selectedInventoryItem = this.transform;
			buyButton.gameObject.SetActive(false);
			useButton.gameObject.SetActive(true);
			sellButton.gameObject.SetActive(true);
		}
		else if(this.transform.parent.parent.name == "ShopScrollContent")
		{
			transform.parent.parent.parent.parent.GetComponent<InventoryControllerScript>().selectedShopItem = this.transform;
			buyButton.gameObject.SetActive(true);
			useButton.gameObject.SetActive(false);
			sellButton.gameObject.SetActive(false);
		}
	}

	public void IncreaseAmount(int amt)
	{
		amount += amt;
		transform.FindChild("AmountCount").GetComponent<Text>().text = amount.ToString();
	}

	public void DecreaseAmount(int amt)
	{
		amount -= amt;
		transform.FindChild("AmountCount").GetComponent<Text>().text = amount.ToString();
	}

	public void BuyButton()
	{
		InventoryControllerScript.Instance.BuyItem();
	}

	public void SellButton()
	{
		InventoryControllerScript.Instance.SellItem();
	}

	public void UseButton()
	{
		InventoryControllerScript.Instance.UseItem();
	}
}
