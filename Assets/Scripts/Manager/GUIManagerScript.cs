using UnityEngine;
using System.Collections;

public class GUIManagerScript : MonoBehaviour
{
	private static GUIManagerScript mInstance;

	public static GUIManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("GUIManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_GUIManager");
					mInstance = obj.AddComponent<GUIManagerScript>();
				}
				else
				{
					mInstance = tempObject.GetComponent<GUIManagerScript >();
				}
			}
			return mInstance;
		}
	}

	bool isPaused = false;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			if(!isPaused)
			{
				Pause();
			}
			else
			{
				Resume();
			}
		}
	}

	public void Pause()
	{
		isPaused = true;
		Time.timeScale = 0;
	}

	public void Resume()
	{
		isPaused = false;
		Time.timeScale = 1;
	}

	public void ItemButton()
	{
		
	}

	public void MoveButton()
	{

	}

	public void StatsButton()
	{

	}
}
