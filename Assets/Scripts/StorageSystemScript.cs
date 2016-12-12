using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class StorageSystemScript : MonoBehaviour
{
	public Text storageText, keypadText; // Storage string for displaying bank value & Keypad string for displaying desired transaction

	int maxNumber; // Maximum transaction digit length
	int playerStorage; // Player's bank
	int keypadTextValue = 0; // The amount entered by player converted into INT32

	// Use this for initialization
	void Start ()
	{
		maxNumber = 5;
		keypadText.text = null;
		playerStorage = 500;
		UpdateStorageText();
	}

	void Update ()
	{
		Int32.TryParse(keypadText.text, out keypadTextValue); // Transforming Keypad string to INT32 value
	}

	void UpdateStorageText()
	{
		storageText.text = playerStorage.ToString();
	}

	public void Deposit()
	{
		// To be added: Check if player has this much amount to deposit
		playerStorage += keypadTextValue;
		UpdateStorageText();
	}

	public void Withdraw()
	{
		if(playerStorage > 0)
		{
			if(playerStorage-keypadTextValue >= 0)
			{
				playerStorage -= keypadTextValue;
				// To be added: playercurrency += keypadTextValue
			}
			else
			{
				playerStorage = 0;
				// Add playercurrency += playerStorage
			}

			UpdateStorageText();
		}
	}

	public void Clear()
	{
		keypadText.text = null;
	}

	public void Zero()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "0";
			}
			else
			{
				keypadText.text = keypadText.text+"0";
			}
		}
	}

	public void One()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "1";
			}
			else
			{
				keypadText.text = keypadText.text+"1";
			}
		}
	}

	public void Two()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "2";
			}
			else
			{
				keypadText.text = keypadText.text+"2";
			}
		}
	}

	public void Three()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "3";
			}
			else
			{
				keypadText.text = keypadText.text+"3";
			}
		}
	}

	public void Four()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "4";
			}
			else
			{
				keypadText.text = keypadText.text+"4";
			}
		}
	}

	public void Five()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "5";
			}
			else
			{
				keypadText.text = keypadText.text+"5";
			}
		}
	}

	public void Six()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "6";
			}
			else
			{
				keypadText.text = keypadText.text+"6";
			}
		}
	}

	public void Seven()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "7";
			}
			else
			{
				keypadText.text = keypadText.text+"7";
			}
		}
	}

	public void Eight()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "8";
			}
			else
			{
				keypadText.text = keypadText.text+"8";
			}
		}
	}

	public void Nine()
	{
		if(keypadText.text.Length < maxNumber)
		{
			if(keypadText.text.Length == 0)
			{
				keypadText.text = "9";
			}
			else
			{
				keypadText.text = keypadText.text+"9";
			}
		}
	}
}
