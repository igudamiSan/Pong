using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class right : MonoBehaviour {

	// Use this for initialization
	void Start()
	{
		float halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		transform.position = new Vector3(halfWorldWidth+3f, transform.position.y, 0);
	}

}
