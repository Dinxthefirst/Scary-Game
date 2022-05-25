using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streetlight : MonoBehaviour
{
    public StreetlightLights[] streetlightsLights;

    GameObject player;

    void Awake()
    {
        foreach (StreetlightLights l in streetlightsLights)
        {
            l.streetLight = l.streetLight.gameObject;
            l.lightTrigger = l.streetLight.transform.Find("Light Trigger").GetComponent<Collider>();
            l.light = l.streetLight.transform.Find("Light").GetComponent<Light>();
        }
    }

    void Start()
    {
        for (int i = 0; i < streetlightsLights.Length; i++)
        {
            streetlightsLights[i].light.gameObject.SetActive(false);
        }
        streetlightsLights[0].light.gameObject.SetActive(true);
        player = GameObject.Find("Player");
    }

    void Update()
    {
        for (int i = 0; i < streetlightsLights.Length-1; i++)
        {
            if (streetlightsLights[i].lightTrigger.bounds.Contains(player.transform.position))
            {
                streetlightsLights[i].light.gameObject.SetActive(false);
                streetlightsLights[i+1].light.gameObject.SetActive(true);
            }
        }
    }
}
