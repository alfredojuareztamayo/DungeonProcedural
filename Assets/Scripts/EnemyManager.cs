using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject player;
    EnemieStats enemieStats;
    private void Start()
    {
        enemieStats = GetComponent<EnemieStats>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        setTarget();
    }

    void setTarget()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
       // Debug.Log(dist);
        if(dist < 7)
        {
            enemieStats.setTarget(player.transform);
        }
        else
        {
            enemieStats.setTarget(null);
        }
    }
}
