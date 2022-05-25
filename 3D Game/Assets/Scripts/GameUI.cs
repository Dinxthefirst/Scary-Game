using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    
    public Text coinText;
    public Text batteryText;

    public void UpdateCoinText(string text)
    {
        coinText.text = "Coins: " + text;
    }

    public void UpdateBatteryText(float battery)
    {
        batteryText.text = "Battery: " + battery.ToString("F0") + "%";
    } 
}
