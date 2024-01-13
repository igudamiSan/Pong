using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen,SettingsScreen;
	public Text scoreLeft, scoreRight,GenNumText;
	public bool ballRandom;
	public int GenNum = 1;

	BallMove BallMoveObj = new BallMove();
	PlayerAISpawn PlayerAISpawnObj = new PlayerAISpawn();

	void Start () {
		FindObjectOfType<BallMove>().BallOut += OnGameOver;

		scoreLeft.text = (PlayerPrefs.GetInt("P1",0)).ToString();
		scoreRight.text=(PlayerPrefs.GetInt("P2",0)).ToString();
	}

	void Update()
	{
		if (BallMoveObj.GameOverBool==true)
		{ 
			//Input.GetKeyDown(KeyCode.Space))

			SceneManager.LoadScene(0);
			PlayerAISpawnObj.PaddleSpawned = false;
			BallMoveObj.GameOverBool = false;
			GenNum += 1;
			GenNumText.text = "GEN " + GenNum.ToString();
			print("After Game Over");
			FindObjectOfType<ButtonToSettings>().OnPlay();
		}
	}


	void Settings()
	{
		SettingsScreen.SetActive(true);
	}
	void OnGameOver()
	{
		gameOverScreen.SetActive(true);
		if (FindObjectOfType<BallMove>().winSide)
		{
			PlayerPrefs.SetInt("P1", PlayerPrefs.GetInt("P1", 0)+1);
			scoreLeft.text = (PlayerPrefs.GetInt("P1",0)).ToString();
		}
		else
		{
			PlayerPrefs.SetInt("P2", PlayerPrefs.GetInt("P2", 0) + 1);
			scoreRight.text = (PlayerPrefs.GetInt("P2", 0)).ToString();
		}
	}
	public void ResetScore()
	{
		PlayerPrefs.DeleteKey("P1");
		PlayerPrefs.DeleteKey("P2");
	}
	
}
