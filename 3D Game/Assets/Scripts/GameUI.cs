using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public Text coinText;
    public Text batteryText;
    public Text objectiveText;

    void Start() 
    {
        UpdateObjectiveText(0);
    }

    public void UpdateCoinText(string text)
    {
        coinText.text = "Coins: " + text;
    }

    public void UpdateBatteryText(float battery)
    {
        batteryText.text = "Battery: " + battery.ToString("F0") + "%";
    }

    public void UpdateObjectiveText(int state)
    {
        if (state == 0) 
        {
            objectiveText.text = "Objective: Survive";
        }
        if (state == 1)
        {
            objectiveText.text = "Objective: Find coins inside house";
        }
        if (state == 2)
        {
            objectiveText.text = "Objective: Input coins into slot machine";
        }
    }
}
