using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    float volume = StateNameController.volume;

    void Awake() 
    {
        foreach (Sound s in sounds)
        {
            s.source = s.audioObject.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume * volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        StartCoroutine(RandomScream());
        Play("Forest Ambient");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopPlaying (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    IEnumerator RandomScream()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(30f, 60f));
            Play("Random Scream");
        }
    }
}

