using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	float halfWorldHeight;
	void Start()
	{
		halfWorldHeight = Camera.main.orthographicSize;
	}
	void Update () {
		if (transform.position.y < -transform.localScale.y / 2f - halfWorldHeight)
		{
			Destroy(gameObject);
		}
	}
}
