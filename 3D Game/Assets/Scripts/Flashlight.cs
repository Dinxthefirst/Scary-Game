using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlightLight;
    bool flashlightActive;
    public float flashlightBattery = 100f;
    public GameUI gameUI;

    void Start()
    {
        flashlightLight.gameObject.SetActive(false);
        flashlightActive = false;
        gameUI.UpdateBatteryText(flashlightBattery);
        StartCoroutine(BatteryDecrease());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flashlightActive && flashlightBattery > 0)
            {
                flashlightLight.gameObject.SetActive(true);
                flashlightActive = true;
            }
            else if (flashlightActive)
            {
                flashlightLight.gameObject.SetActive(false);
                flashlightActive = false;
            }
        }
    }

    IEnumerator BatteryDecrease()
    {
        while (true)
        {
            if (flashlightBattery <= 0)
            {
                flashlightLight.gameObject.SetActive(false);
                flashlightActive = false;
                break;
            }
            
            while (flashlightActive && flashlightBattery > 0)
            {
                flashlightBattery -= .05f;
                gameUI.UpdateBatteryText(flashlightBattery);
                yield return new WaitForSeconds(.1f);
            }
            yield return null;
        }
    }
}
