using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("punch"))
        {

            PlayerStat stats = GetComponent<PlayerStat>();
            stats.damagePlayer(10f);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("punch"))
    //    {

    //        PlayerStat stats = GetComponent<PlayerStat>();
    //        stats.damagePlayer(10f);
    //    }
    //}
}
