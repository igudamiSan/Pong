using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    public string name;
    public AudioClip audio;
    [HideInInspector]
    public AudioSource source;
    
    [Range(0,1)]
    public float volume;
    [Range(0.7f,3.0f)]
    public float pitch;
}
