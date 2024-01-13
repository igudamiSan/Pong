using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePaddle : MonoBehaviour {

	// Use this for initialization
	public Rigidbody Rigidbody;
	float halfWorldHeight;
	public float speed=25;
	public Transform Ball;
	public GameObject Paddle;
	public Text singleMulti;
	float speedAI;
	public Text difficultyLevel;
	public bool multiplayer;
	void Start()
	{
		halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		transform.position = new Vector3(-halfWorldWidth+0.5f , transform.position.y, 0);
	}


	// Update is called once per frame
	void Update() {
		if (singleMulti.text == "Multi Player")
		{
			multiplayer = true;
			if (Input.GetKey(KeyCode.W))
			{
				Rigidbody.velocity = Vector3.up * speed;
			}
			else if (Input.GetKey(KeyCode.S))
			{
				Rigidbody.velocity = Vector3.down * speed;
			}
			if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
			{
				Rigidbody.velocity = Vector3.zero;
			}
		}else if (singleMulti.text == "Single Player")
		{
			multiplayer = false;
			AISpeedSet();
			if (Ball.position.y > transform.position.y)
			{
				Paddle.GetComponent<Rigidbody>().velocity = Vector3.up * speedAI;
			}
			else if (Ball.position.y < transform.position.y)
			{
				Paddle.GetComponent<Rigidbody>().velocity = Vector3.down * speedAI;
			}
			else
			{
				Paddle.GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}
	}
	void AISpeedSet()
	{
		if(difficultyLevel.text=="Too Easy..")
		{
			speedAI = 3f;
		}else if (difficultyLevel.text == "Easy")
		{
			speedAI = 6f;
		}
		else if (difficultyLevel.text == "Medium")
		{
			speedAI = 8f;
		}
		else if (difficultyLevel.text == "Hard")
		{
			speedAI = 10f;
		}
		else if (difficultyLevel.text == "Impossible")
		{
			speedAI = 13f;
		}
	}
}
