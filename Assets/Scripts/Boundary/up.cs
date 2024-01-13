using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class up : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		float halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		transform.position = new Vector3(transform.position.x, halfWorldHeight+transform.localScale.y/2f, 0);
	}
}
