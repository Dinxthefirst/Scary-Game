using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;
    public Transform[] coinSpawnPoints;
    [HideInInspector]public int coinAmount;

    void Start() 
    {
        coinAmount = 0;
        SpawnCoins();
        print("Coin Amount: " + coinAmount);
    }

    void SpawnCoins() 
    {
        for(int i = 0; i < coinSpawnPoints.Length; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                Instantiate(coin, coinSpawnPoints[i].position, coinSpawnPoints[i].rotation);
                coinAmount += 1;
            }
        }
    }
}
