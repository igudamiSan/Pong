using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayer : MonoBehaviour {

	public Text PlayerWin,SingleMulti;
	public GameObject Input1,Input2;
	public GameObject PlaceHolder1, PlaceHolder2;
	// Use this for initialization
	
	void Start()
	{
		PlaceHolder1.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerOne", "Player 1");
		PlaceHolder2.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerTwo", "Player 2");
	}

	void Update()
	{
		/*if ( FindObjectOfType<MovePaddle>().multiplayer)
		{
			if (FindObjectOfType<BallMove>().winSide)
			{
				PlayerWin.text = PlayerPrefs.GetString("PlayerTwo","Player 2")+" Wins!!";
			}
			else
			{
				PlayerWin.text = PlayerPrefs.GetString("PlayerOne", "Player 1")+" Wins!!";
			}
		}*/
	}
	public void NameConfirm()
	{
		PlayerPrefs.SetString("PlayerOne", (Input1.GetComponent<InputField>()).text);
		PlayerPrefs.SetString("PlayerTwo", (Input2.GetComponent<InputField>()).text);
		PlaceHolder1.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerOne","Player 1");
		PlaceHolder2.GetComponent<Text>().text = PlayerPrefs.GetString("PlayerTwo", "Player 2");
	}

}
