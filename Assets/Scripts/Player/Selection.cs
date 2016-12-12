using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour 
{
	public void SelectPlayer (int counter)
	{
		if (counter == 1)
		{
			PlayerPrefs.SetString ("Name", "Sadako");
		}
		else if (counter == 2)
		{
			PlayerPrefs.SetString ("Name", "Kayako");
		}
		else if (counter == 3)
		{
			PlayerPrefs.SetString ("Name", "Jami");
		}
		else if (counter == 4)
		{
			PlayerPrefs.SetString ("Name", "DemonFox");
		}
	}
	

}
