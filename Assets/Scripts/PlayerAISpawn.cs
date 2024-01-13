using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAISpawn : MonoBehaviour {


	public GameObject PlayerPaddle;
	
	public int paddleNum = 1;
	public bool paddleSpawned = false;
	public float[] newWeights = new float[12];
	
	public bool PaddleSpawned
	{
		get
		{
			return paddleSpawned;
		}
		set
		{
			paddleSpawned = value;
		}
	}
	Vector3 spawnPos;
	
	void Start () {
		SpawnPositionSet();
		
	}
	
	// Update is called once per frame
	void Update () {
		Spawner();
		print(newWeights[0]);
	}
	void SpawnPositionSet()
	{
		float halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		spawnPos = new Vector3(halfWorldWidth - 0.5f, transform.position.y, 0);
	}

	void Spawner()
	{
		if ( paddleSpawned == false)
		{
			for (int i = 0; i < paddleNum; i++)
			{
				Instantiate(PlayerPaddle, spawnPos, Quaternion.identity);
			}
			paddleSpawned = true;

		}
	}
}
