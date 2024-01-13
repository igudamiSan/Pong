using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MovePaddle2 : MonoBehaviour
{
	public Rigidbody Rigidbody;
	public float speed=25;

	float halfWorldHeight,UpValue,DownValue,StillValue;
	float[] Inputs,weights;
	float timeLeft = 4.5f;
	public float variation = 1;
	int output = 0;
	Vector3 Ball;


	void Start()
	{
		
		PositionSet();
		WeightAssign();
		StartCoroutine(DestroyTimer());
	}

	void Update()
	{

		Ball = FindObjectOfType<BallMove>().BALL.position;
		output= NeuralNetwork();
		
		PaddleControl(output);

		if (transform.position.x+1f < Ball.x && !FindObjectOfType<BallMove>().gameOverBool)
		{
			FindObjectOfType<PlayerAISpawn>().newWeights = weights;
			print("New Weight Set");
			Destroy(gameObject);
		}
		
		
	}

	void PositionSet()
	{
		halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		transform.position = new Vector3(halfWorldWidth - 0.5f, transform.position.y, 0);
	}

	void PlayerControls()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Rigidbody.velocity = Vector3.up * (speed + 0.001f);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			Rigidbody.velocity = Vector3.down * (speed + 0.001f);
		}
		if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
		{
			Rigidbody.velocity = Vector3.zero;
		}
	}

	void PaddleControl(int directon)
	{
		if (directon==1)
		{
			Rigidbody.velocity = Vector3.up * (speed );
		}
		else if (directon ==-1)
		{
			Rigidbody.velocity = Vector3.down * (speed);
		}
		else
		{
			Rigidbody.velocity = Vector3.zero;
		}
	}

	void WeightAssign()
	{
		if (PlayerPrefs.GetInt("weightAssigned", 0)==0)// if the array in PlayerAISpawn doesnt have any values in it
		{

			weights = new float[12];
			for (int i = 0; i < 12; i++)
			{
				weights[i] = UnityEngine.Random.Range(-1f, 1f);
				
			}
		}
		else
		{
			DecreaseVariation();
			weights = FindObjectOfType<PlayerAISpawn>().newWeights;
			for (int i = 0; i < 12; i++)
			{
				weights[i] += (UnityEngine.Random.Range(-variation, variation)/variation+1f);

			}
		}
		PlayerPrefs.SetInt("weightAssigned", PlayerPrefs.GetInt("weightAssigned", 0)+1);

	}

	void InputAssign()
	{
		Inputs = new float[4];

		Inputs[0] = Ball.x / 10f;
		Inputs[1] = Ball.y / 4.85f;

		Inputs[2] = transform.position.y / 4f;


		Inputs[3] = 1f;
	
	}

	void OutputVariablesSetZero()
	{
		UpValue = 0f;
		DownValue = 0f;
		StillValue = 0f;
	}

	int ComputeOutput()
	{
		//FIND EACH VALUE 
		for (int i = 0; i <= 3; i+=1)
		{
			for (int j = 0; j <= 2;)
			{

				if (i == 0)
				{
					
					UpValue += Inputs[j] * weights[j];
					
				}

				else if (i == 1)
				{

					DownValue += Inputs[j] * weights[j + 4];
				}

				else
				{
					StillValue += Inputs[j] * weights[j + 8];
				}
				j++;
			}
		}

		//BACK TO -1,1 RANGE
		UpValue = UpValue / 4f;
		
		DownValue = DownValue / 4f;
		//print(DownValue + "DownValue");

		StillValue = StillValue / 4f;
		//print(StillValue + "StillValue");

		//FIND MAX VALUE
		int Output = 0;

		if (Mathf.Max(UpValue, DownValue, StillValue) == UpValue)
		{
			Output = 1;
		}
		else if (Mathf.Max(UpValue, DownValue, StillValue) == DownValue)
		{
			Output = -1;
		}
		else
		{
			Output = 0;
		}
		return Output;
	}

	int NeuralNetwork()
	{
		
		InputAssign();
		
		OutputVariablesSetZero();

		int output=ComputeOutput();
		return output;
	}

	IEnumerator DestroyTimer()
	{
		yield return new WaitForSeconds(1f);
		timeLeft -= 1;
		if (timeLeft <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "Ball")
		{
			timeLeft = 4.5f;
		}
	}

	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("weightAssigned",0);
	}

	void DecreaseVariation()
	{
		variation = variation * (95 / 100);
	}
}