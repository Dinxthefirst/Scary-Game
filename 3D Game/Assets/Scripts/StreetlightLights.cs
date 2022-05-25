using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StreetlightLights
{
    public GameObject streetLight;
    [HideInInspector]public Light light;
    [HideInInspector]public Collider lightTrigger;
}
