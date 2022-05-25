using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    int coins;
    public int totalCoins;

    CoinSpawner coinSpawner;

    public float lookDistance = 5f;
    RaycastHit hit;
    public GameUI gameUI;

    SlotMachine slotMachine;
    Door door;
    
    void Start()
    {
        coins = 0;
        slotMachine = FindObjectOfType<SlotMachine>();
        door = FindObjectOfType<Door>();
        coinSpawner = FindObjectOfType<CoinSpawner>();
        gameUI.UpdateCoinText((coins + "/" + coinSpawner.coinAmount).ToString());
    }

    void Update()
    {
        RaycastFromCamera();
    }

    void RaycastFromCamera()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * lookDistance, Color.white);

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(ray, out hit, lookDistance)) // change to collider
            {
                Debug.DrawLine(ray.origin, ray.direction * lookDistance, Color.red);
                if (hit.collider.gameObject.tag == "Coin")
                {
                    LookingAtCoin();
                }
                if (hit.collider.gameObject.tag == "Slot Machine")
                {
                    LookingAtSlotMachine();
                }
            }
        }
    }

    void LookingAtCoin() 
    {
        coins++;
        totalCoins++;
        if(totalCoins >= coinSpawner.coinAmount)
        {
            door.OpenDoor();
        }
        Destroy(hit.collider.gameObject);
        gameUI.UpdateCoinText((coins + "/" + coinSpawner.coinAmount).ToString());
    }

    void LookingAtSlotMachine() 
    {
        if (coins > 0)
        {
            coins--;
            slotMachine.AddCoins();
            gameUI.UpdateCoinText((coins + "/" + coinSpawner.coinAmount).ToString());
        }
    }
}