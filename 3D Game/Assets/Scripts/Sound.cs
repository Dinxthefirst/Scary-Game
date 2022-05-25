using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    [HideInInspector]public AudioSource source;
    public GameObject audioObject;
    
    public AudioClip clip;
    [Range(0, 1)]public float volume;
    [Range(0, 3)]public float pitch;

    [Range(0, 1)]public float spatialBlend;

    public bool playOnAwake;

    public bool loop;

}
