using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineSpawn : MonoBehaviour
{


	public Text ObjectChange;
	public Vector3 spawnPosition;
	float halfWorldHeight;
	//BLOCK CHANGE OBJECTS
	public GameObject Sphere;
	public GameObject cube;
	public GameObject Line;
	void Start()
	{
		halfWorldHeight = Camera.main.orthographicSize;
		float halfWorldWidth = Camera.main.aspect * halfWorldHeight;
		spawnPosition = new Vector3(Random.Range(-Time.time%2,Time.time%2), halfWorldHeight, 0);

	}
	void Update()
	{

		if (PlayerPrefs.GetInt("forBool",0)>0) {
			if (ObjectChange.text == "Line")
			{
				FindObjectOfType<LineSpawn>().spawnPosition = new Vector3(Random.Range(-Time.time % 2, Time.time % 2), halfWorldHeight + FindObjectOfType<LineSpawn>().Line.GetComponent<Transform>().localScale.y, 0);
			}else if(ObjectChange.text == "Sphere")
			{
				FindObjectOfType<LineSpawn>().spawnPosition = new Vector3(Random.Range(-Time.time % 2, Time.time % 2), halfWorldHeight + FindObjectOfType<LineSpawn>().Sphere.GetComponent<Transform>().localScale.y, 0);
			}else if (ObjectChange.text == "Square")
			{
				FindObjectOfType<LineSpawn>().spawnPosition = new Vector3(Random.Range(-Time.time % 2, Time.time % 2), halfWorldHeight + FindObjectOfType<LineSpawn>().cube.GetComponent<Transform>().localScale.y, 0);
			}
			FindObjectOfType<LineSpawn>().SpawnLine();
		}
	}
	public void SpawnLine()
	{
		float time = Time.time;
		if (Random.Range(time, time + 50) <= time + 1)
		{
			if (ObjectChange.text=="Sphere") {
				Instantiate(Sphere, spawnPosition, Quaternion.identity);
				Sphere.GetComponent<Rigidbody>().velocity = Vector3.down;
			}
			else if(ObjectChange.text == "Line"){
				Instantiate(Line, spawnPosition, Quaternion.identity);
				Line.GetComponent<Rigidbody>().velocity = Vector3.down;
			}
			else if(ObjectChange.text == "Square"){
				Instantiate(cube, spawnPosition, Quaternion.identity);
				cube.GetComponent<Rigidbody>().velocity = Vector3.down;
			}
		}
	}
}