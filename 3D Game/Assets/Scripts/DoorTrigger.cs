using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    public GameObject monster;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().lookedAtSlotMachine = true;
            other.gameObject.GetComponent<Player>().UpdateObjectiveText(1);
            door.CloseDoor();
            monster.SetActive(true);
            Destroy(gameObject);
        }
    }
}
