using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{

	public Transform Ball;
	public Rigidbody BALL;
	public GameObject Bounce;
	float halfWorldHeight;
	float ballX, ballY;
	public bool gameOverBool=false;
	public bool GameOverBool
	{
		get
		{
			return gameOverBool;
		}
		set
		{
			gameOverBool = value;
		}
	}

	public bool winSide;//false-left
	public event System.Action BallOut;
	public Text difficultyLevel;

	// Use this for initialization
	void Start()
	{
		halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		RandomBallMovement();
	}
	
	void OnTriggerEnter(Collider collideBall)
	{
		if (collideBall.tag == "boundary")
		{
			BALL.velocity = new Vector3(BALL.velocity.x, -BALL.velocity.y, 0);
		}
		else if (collideBall.tag=="FallLine")
		{
			BALL.velocity = new Vector3(-BALL.velocity.x,BALL.velocity.y,0);
		}
		else if (collideBall.tag == "CubeSide")
		{
			print("CubeSide");
			BALL.velocity = new Vector3(-BALL.velocity.x,BALL.velocity.y,0);
		}
		else if (collideBall.tag == "Paddle")
		{
			if(BALL.velocity.x<ballX || BALL.velocity.y < ballY/2f )
			{
				if (ballX > 0)
				{
					if (BALL.velocity.y >= 0 && ballY > 0 || BALL.velocity.y <= 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(ballX, ballY, 0);
					}
					else if (BALL.velocity.y < 0 && ballY > 0 || BALL.velocity.y > 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(ballX, -ballY, 0);
					}
				}
				else
				{
					if (BALL.velocity.y >= 0 && ballY > 0 || BALL.velocity.y <= 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(-ballX, ballY, 0);
					}
					else if (BALL.velocity.y < 0 && ballY > 0 || BALL.velocity.y > 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(-ballX, -ballY, 0);
					}
				}
			}
			else
			{
				BALL.velocity = new Vector3(-BALL.velocity.x + 0.1f, BALL.velocity.y, 0);
			}
		}
		else if (collideBall.tag == "PaddleTop")
		{
			
			if (BALL.velocity.x < ballX || BALL.velocity.y < ballY)
			{
				if (ballX > 0)
				{
					if (BALL.velocity.y >= 0 && ballY>0 || BALL.velocity.y <= 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(-ballX, ballY, 0);
					}
					else if(BALL.velocity.y < 0 && ballY > 0 || BALL.velocity.y > 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(-ballX, -ballY, 0);
					}
				}
				else
				{

					if (BALL.velocity.y >= 0 && ballY > 0 || BALL.velocity.y <= 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(ballX, ballY, 0);
					}
					else if (BALL.velocity.y < 0 && ballY > 0 || BALL.velocity.y > 0 && ballY < 0)
					{
						BALL.velocity = new Vector3(ballX, -ballY, 0);
					}
				}
			}
			else
			{
				BALL.velocity = new Vector3(-BALL.velocity.x - 0.1f, BALL.velocity.y, 0);
			}	
		}
		else if (collideBall.tag == "GameOver")
		{
			winSide = false;
			gameOverBool = true;
			BallOut();
		}
		else if (collideBall.tag == "GameOver1")
		{
			winSide = true;
			gameOverBool = true;
			BallOut();

		}
	}
	public void RandomBallMovement()
	{
		float time = Time.time;
		float rand1;
		float LR;
		rand1 = Random.Range(time - 2, time);
		if (rand1 > time - 1)
		{
			LR = -1;
		}
		else
		{
			LR = 1;
		}
		ballX = (10) * LR;
		float UD;
		float rand2 = Random.Range(time - 4, time);
		if (rand2 > time - 2)
		{
			UD = -1;
		}
		else
		{
			UD = 1;
		}
		ballY = (8 + time % 3) * UD;
		BALL.velocity = new Vector3(ballX * (3 / 4f), ballY, 0);
		BallSpeedSet();
	}
	void BallSpeedSet()
	{
		if (difficultyLevel.text == "Too Easy..")
		{
			BALL.velocity *= 0.8f;
		}
		else if (difficultyLevel.text == "Easy")
		{
			BALL.velocity *= 0.9f;
		}
		else if (difficultyLevel.text == "Medium")
		{
			BALL.velocity *= 1.3f;
		}
		else if (difficultyLevel.text == "Hard")
		{
			BALL.velocity *= 1.5f;
		}
		else if (difficultyLevel.text == "Impossible")
		{
			BALL.velocity *= 1.7f;
		}
	}
}
