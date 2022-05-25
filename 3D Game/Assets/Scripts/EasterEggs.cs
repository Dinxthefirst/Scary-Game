using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEggs : MonoBehaviour
{
    public GameObject easterEggs;

    public KeyCode[] keyCodeSeries;
    int keyCodeIndex = 0;
    float lastKeyPressTime;
    bool konamiActive;

    AudioManager audioManager;

    void Start()
    {
        keyCodeIndex = 0;
        easterEggs.SetActive(true);
        audioManager = FindObjectOfType<AudioManager>();
        konamiActive = false;
    }

    void Update()
    {
        KonamiCode();
        
    }

    void KonamiCode()
    {
        if (Input.GetKeyDown(keyCodeSeries[keyCodeIndex]))
        {
            keyCodeIndex++;
            if (keyCodeIndex == keyCodeSeries.Length && !konamiActive)
            {
                konamiActive = true;
                audioManager.Play("Pyramid Head");
                audioManager.StopPlaying("Creepy Ambient");
                keyCodeIndex = 0;
            }
        }

        else if (Input.anyKeyDown)
        {
            keyCodeIndex = 0;
        }
    }
}
