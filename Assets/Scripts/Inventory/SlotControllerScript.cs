using UnityEngine;
using System.Collections;

public class SlotControllerScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void SelectSlot()
	{
		transform.parent.parent.parent.GetComponent<InventoryControllerScript>().selectedSlot = this.transform;
	}
}
