using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLimit : MonoBehaviour {
	public Transform Paddle;
	float halfWorldHeight;
	void Start () {
		halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
	}
	
	// Update is called once per frame
	void Update () {
		if (Paddle.position.y > halfWorldHeight - Paddle.localScale.y / 2f)
		{
			Paddle.position = new Vector3(Paddle.position.x, halfWorldHeight - Paddle.localScale.y / 2f, 0);
		}else if (Paddle.position.y < -halfWorldHeight+Paddle.localScale.y/2f)
		{
			Paddle.position = new Vector3(Paddle.position.x, -halfWorldHeight +Paddle.localScale.y / 2f, 0);
		}
	}
}
