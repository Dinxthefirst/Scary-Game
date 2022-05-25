using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    GameObject doorRotator;
    AudioManager audioManager;

    
    void Start()
    {
        doorRotator = gameObject.transform.GetChild(0).gameObject;
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    
    public void OpenDoor()
    {
        doorRotator.transform.rotation = Quaternion.Euler(0, -120, 0);
        audioManager.Play("Door Open");
        audioManager.Play("Forest Ambient");
        audioManager.StopPlaying("House Ambient");
    }

    public void CloseDoor()
    {
        doorRotator.transform.rotation = Quaternion.Euler(0, 0, 0);
        audioManager.Play("Door Close");
        audioManager.Play("House Ambient");
        audioManager.StopPlaying("Forest Ambient");
    }
}
