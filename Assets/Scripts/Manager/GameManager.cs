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
	Vector3 cameraOffset;

	public List<GameObject> playersPrefabs;
	public List<Player.Movement> players;
	public int currentPlayerIndex = 0;

	void Start () 
	{
		SpawnPlayers();
		cameraOffset = mCamera.transform.position - players[0].transform.position;
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

	public void PlayerBuyTile()
	{
		players[currentPlayerIndex].BuyUpgradeTile();
	}

	void SpawnPlayers()
	{
		Player.Movement tempPlayer = ((GameObject) Instantiate(playersPrefabs[0], new Vector3(-14f, -0.54f, 10.0f), Quaternion.identity)).GetComponent<Player.Movement>();
		tempPlayer.colIndex = 2;
		tempPlayer.rowIndex = 2;
		players.Add(tempPlayer);
		tempPlayer.bot = false;
		int rand = Random.Range(1, 3);
		switch(rand)
		{
		case 1:
			tempPlayer.gameObject.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
			break;

		case 2:
			tempPlayer.gameObject.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			break;
		}

		Player.Movement tempPlayer2 = ((GameObject) Instantiate(playersPrefabs[1], new Vector3(-15f, -0.54f, 10.0f), Quaternion.identity)).GetComponent<Player.Movement>();
		tempPlayer2.colIndex = 1;
		tempPlayer2.rowIndex = 2;
		players.Add(tempPlayer2);
		tempPlayer2.bot = true;
		rand = Random.Range(1, 3);
		switch(rand)
		{
		case 1:
			tempPlayer2.gameObject.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
			break;

		case 2:
			tempPlayer2.gameObject.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			break;
		}

		Player.Movement tempPlayer3 = ((GameObject) Instantiate(playersPrefabs[2], new Vector3(-14f, -0.54f, 11.0f), Quaternion.identity)).GetComponent<Player.Movement>();
		tempPlayer3.colIndex = 2;
		tempPlayer3.rowIndex = 1;
		players.Add(tempPlayer3);
		tempPlayer3.bot = true;
		rand = Random.Range(1, 3);
		switch(rand)
		{
		case 1:
			tempPlayer3.gameObject.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
			break;

		case 2:
			tempPlayer3.gameObject.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			break;
		}

		Player.Movement tempPlayer4 = ((GameObject) Instantiate(playersPrefabs[3], new Vector3(-15f, -0.54f, 11.0f), Quaternion.identity)).GetComponent<Player.Movement>();
		tempPlayer4.colIndex = 1;
		tempPlayer4.rowIndex = 1;
		players.Add(tempPlayer4);
		tempPlayer4.bot = true;
		rand = Random.Range(1, 3);
		switch(rand)
		{
		case 1:
			tempPlayer4.gameObject.transform.localEulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
			break;

		case 2:
			tempPlayer4.gameObject.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
			break;
		}
	}

}
