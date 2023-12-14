using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRoomVisited : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStat playerStat = other.GetComponent<PlayerStat>();
            playerStat.increseRooms();
            Destroy(gameObject);
        }
    }
}
