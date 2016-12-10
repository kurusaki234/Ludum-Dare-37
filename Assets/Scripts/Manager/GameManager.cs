using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	private static GameManager mInstance;

	public static GameManager Instance
	{
		get
		{
			if(mInstance == null)
			{
				GameObject tempObject = GameObject.FindGameObjectWithTag("GameManager");

				if(tempObject == null)
				{
					GameObject obj = new GameObject("_GameManager");
					mInstance = obj.AddComponent<GameManager>();
				}
				else
				{
					mInstance = tempObject.GetComponent<GameManager >();
				}
			}
			return mInstance;
		}
	}

	public GameObject uiCanvas;
	public Camera mCamera;
	public Vector3 playerPosition;
	Vector3 cameraOffset;

	public List<GameObject> playersPrefabs;
	public List<Player.Movement> players;
	public int currentPlayerIndex = 0;

	void Start () 
	{
		SpawnPlayers();
		cameraOffset = mCamera.transform.position - playersPrefabs[0].transform.position;
	}


	void Update () 
	{
		
	}

	public void CameraFollow()
	{
		mCamera.transform.position = players[currentPlayerIndex].gameObject.transform.position + cameraOffset;
	}

	public void NextTurn()
	{
		if(currentPlayerIndex + 1 < players.Count)
		{
			currentPlayerIndex ++;
		}
		else
		{
			currentPlayerIndex = 0;
		}

		if(players[currentPlayerIndex].bot == false)
		{
			uiCanvas.SetActive(true);
		}
		else
		{
			players[currentPlayerIndex].Move();
		}

		GameManager.Instance.CameraFollow();
	}

	public void PlayerMove()
	{
		players[currentPlayerIndex].Move();
		uiCanvas.SetActive(false);
	}

	void SpawnPlayers()
	{
		for(int i = 0; i < playersPrefabs.Count; i++)
		{
			Player.Movement tempPlayer = ((GameObject) Instantiate(playersPrefabs[i], new Vector3(-12.0f, 0.5f, 8.0f), Quaternion.identity)).GetComponent<Player.Movement>();
			tempPlayer.colIndex = 0;
			tempPlayer.rowIndex = 0;
			players.Add(tempPlayer);

			if(i == 0)
			{
				tempPlayer.bot = false;
			}
		}
	}
}
