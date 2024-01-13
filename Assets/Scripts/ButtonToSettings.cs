using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonToSettings : MonoBehaviour
{

	public GameObject SettingsScreen;
	public Text difficultyLevel;
	public Text singleMulti;
	public bool startScreenOff;
	public GameObject StartScreen;
	public bool playClick;
	public Text Object;
	public GameObject Popup,GameResetPrompt;
	public Text Name1, Name2;
	bool P1, P2;
	float halfWorldHeight;

	void Start()
	{
		halfWorldHeight = Camera.main.orthographicSize;
		//PlayerPrefs.SetInt("forBool", 0);
		difficultyLevel.text = PlayerPrefs.GetString("difficulty", "Too Easy..");
		singleMulti.text = PlayerPrefs.GetString("PlayerSM", "Single Player");
		Object.text = PlayerPrefs.GetString("block", "Sphere");
		if (PlayerPrefs.GetInt("forBool", 0)>0) {
			
			StartScreen.SetActive(false);
			FindObjectOfType<BallMove>().RandomBallMovement();
			FindObjectOfType<LineSpawn>().SpawnLine();

		}

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Popup.activeInHierarchy)
			{
				Cancel();
			}
			else
			{
				Quit();
			}
		}
		
	}
	public void Settings()
	{
		SettingsScreen.SetActive(true);
	}
	public void BackFromSettings()
	{
		SettingsScreen.SetActive(false);
	}
	public void DifficultyMeter()
	{
		int clicks = PlayerPrefs.GetInt("clickNo", 0);
		PlayerPrefs.SetInt("clickNo", PlayerPrefs.GetInt("clickNo", 0) + 1);
		if (PlayerPrefs.GetInt("clickNo", 0)== 5)
		{
			PlayerPrefs.SetString("difficulty", "Too Easy..");
			PlayerPrefs.SetInt("clickNo", 0);
		}
		if (PlayerPrefs.GetInt("clickNo", 0) == 1)
		{
			PlayerPrefs.SetString("difficulty", "Easy");
		}else if (PlayerPrefs.GetInt("clickNo", 0) == 2)
		{
			PlayerPrefs.SetString("difficulty", "Medium");
		}else if (PlayerPrefs.GetInt("clickNo", 0) == 3)
		{
			PlayerPrefs.SetString("difficulty", "Hard");
		}else if (PlayerPrefs.GetInt("clickNo", 0) == 4)
		{
			PlayerPrefs.SetString("difficulty", "Impossible");
		}
		difficultyLevel.text = PlayerPrefs.GetString("difficulty", "Too Easy..");
	}
	public void PlayerNum()
	{
		int clicks= PlayerPrefs.GetInt("SM", 0);
		string sm= PlayerPrefs.GetString("PlayerSM", "Single Player");
		PlayerPrefs.SetInt("SM", PlayerPrefs.GetInt("SM", 0) + 1);
		if (PlayerPrefs.GetInt("SM", 0) == 0 || PlayerPrefs.GetInt("SM", 0) == 2)
		{
			PlayerPrefs.SetString("PlayerSM","Multi Player");
			PlayerPrefs.SetInt("SM", 0);
		}
		else if (PlayerPrefs.GetInt("SM", 0) == 1)
		{
			PlayerPrefs.SetString("PlayerSM", "Single Player");
		}
		singleMulti.text= PlayerPrefs.GetString("PlayerSM", "Single Player");
	}
	public void OnPlay()
	{
		int one = PlayerPrefs.GetInt("forBool", 0);
		playClick = true;
		StartScreen.SetActive(false);
		PlayerPrefs.SetInt("forBool", PlayerPrefs.GetInt("forBool", 0)+1);
		FindObjectOfType<BallMove>().RandomBallMovement();
		FindObjectOfType<LineSpawn>().SpawnLine();
	}
	public void Quit()
	{
		Popup.SetActive(true);
		Time.timeScale=0;
	}
	public void BlockChange()
	{
		int clicks = PlayerPrefs.GetInt("CLicks",0);
		PlayerPrefs.SetInt("CLicks", PlayerPrefs.GetInt("CLicks", 0)+1);
		if (PlayerPrefs.GetInt("CLicks", 0) == 1)
		{
			PlayerPrefs.SetString("block", "None");
		}else if(PlayerPrefs.GetInt("CLicks", 0) == 2){
			PlayerPrefs.SetString("block", "Line");
		}
		else if (PlayerPrefs.GetInt("CLicks", 0) == 3){
			PlayerPrefs.SetInt("CLicks", 0);
			PlayerPrefs.SetString("block", "Sphere");
		}
		Object.text = PlayerPrefs.GetString("block", "Sphere");
	}
	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("forBool", 0);
	}
	public void Cancel()
	{
		Popup.SetActive(false);
		Time.timeScale = 1;
	}
	public void QuitForReal()
	{
		Application.Quit();
	}
	public void ResetGamePrompt()
	{
		GameResetPrompt.SetActive(true);
	}
	public void ResetGame()
	{
		PlayerPrefs.DeleteAll();
		GameResetPrompt.SetActive(false);
	}
	public void CancelResetGame()
	{
		GameResetPrompt.SetActive(false);
	}
	public GameObject Pong;
	public void Pause()
	{
			Time.timeScale = 0;
			Pong.SetActive(true);	
	}
	public void Resume()
	{
		Time.timeScale = 1;
		Pong.SetActive(false);
	}
}

