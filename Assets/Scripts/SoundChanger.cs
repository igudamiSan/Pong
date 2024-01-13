using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundChanger : MonoBehaviour {

	public Sound[] sounds;
	
	void Awake()
	{
		foreach (Sound i in sounds)
		{
			gameObject.AddComponent<AudioSource>();
		}
	}
}
