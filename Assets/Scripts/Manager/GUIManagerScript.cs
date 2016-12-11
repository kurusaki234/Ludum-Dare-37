using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
					obj.tag = "GUIManager";
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

	public GameObject gameCanvas;
	public GameObject pauseCanvas;
	public GameObject inventoryCanvas;

	void Awake()
	{
		gameCanvas.SetActive(true);
		pauseCanvas.SetActive(false);
		inventoryCanvas.SetActive(false);
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			Pause();
		}
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	public void Pause()
	{
		isPaused = !isPaused;

		if(!isPaused)
		{
			gameCanvas.SetActive(false);
			pauseCanvas.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			gameCanvas.SetActive(true);
			pauseCanvas.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void Back()
	{
		gameCanvas.SetActive(true);
		inventoryCanvas.SetActive(false);
	}

	public void MoveButton()
	{

	}

	public void ItemButton()
	{
		gameCanvas.SetActive(false);
		inventoryCanvas.SetActive(true);
	}

	public void StatsButton()
	{

	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
