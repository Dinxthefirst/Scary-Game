using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    static int coins;

    public bool isSpinning = false;

    AudioManager audioManager;

    WinMenu winMenu;

    CoinSpawner coinSpawner;


    void Start() 
    {
        coins = 0;
        audioManager = FindObjectOfType<AudioManager>();
        winMenu = FindObjectOfType<WinMenu>();
        coinSpawner = FindObjectOfType<CoinSpawner>();
    }

    public void AddCoins()
    {
        coins++;
        if (coins >= coinSpawner.coinAmount)
        {
            audioManager.Play("Slot Machine Win");
            winMenu.PlayerWon();
        }
    }
}
