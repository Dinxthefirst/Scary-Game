using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryMan : MonoBehaviour
{
    
    public float moveRadius = 15f;
    public float moveSpeed = 5f;
    public float disappearRadius = 10f;

    GameObject player;

    AudioManager audioManager;
    bool playingAudio;
    
    void Start()
    {
        player = GameObject.Find("Player");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < moveRadius && Vector3.Distance(player.transform.position, transform.position) > disappearRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position + Vector3.up, moveSpeed * Time.deltaTime);
            PlayScaryManSound();
        }
        if (Vector3.Distance(player.transform.position, transform.position) < disappearRadius) 
        {
            Destroy(gameObject);
        }
    }
    
    void PlayScaryManSound()
    {
        if (!playingAudio)
        {
            playingAudio = true;
            audioManager.Play("Scary Man"); 
        }
    }
}