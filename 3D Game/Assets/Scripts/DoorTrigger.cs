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
            door.CloseDoor();
            monster.SetActive(true);
            Destroy(gameObject);
        }
    }
}
