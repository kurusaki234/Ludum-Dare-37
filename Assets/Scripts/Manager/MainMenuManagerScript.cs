using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManagerScript : MonoBehaviour
{
	private static MainMenuManagerScript mInstance;

	public static MainMenuManagerScript Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("MainMenuManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_MainMenuManager");
					mInstance = obj.AddComponent<MainMenuManagerScript>();
					obj.tag = "MainMenuManager";
				}
				else
				{
					mInstance = tempObject.GetComponent<MainMenuManagerScript>();
				}
			}
			return mInstance;
		}
	}

	public GameObject mainCanvas;
	public GameObject creditCanvas;

	void Awake()
	{
		creditCanvas.SetActive(false);
		mainCanvas.SetActive(true);
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Scene01");
	}

	public void Back()
	{
		creditCanvas.SetActive(false);
		mainCanvas.SetActive(true);
	}

	public void Credit()
	{
		creditCanvas.SetActive(true);
		mainCanvas.SetActive(false);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
