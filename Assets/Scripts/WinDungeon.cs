using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDungeon : MonoBehaviour
{
    public GameObject generator;
    int numberOfRoomsVisited;
    PlayerStat statPlayer;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        statPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStat>();
        numberOfRoomsVisited = statPlayer.getRoomsVisited();
        generator = GameObject.FindGameObjectWithTag("Generator");
    }

    // Update is called once per frame
    void Update()
    {
        winGame();
    }

    void winGame()
    {
        numberOfRoomsVisited = statPlayer.getRoomsVisited();
        int numberOfRoom = generator.transform.childCount;

        if(numberOfRoomsVisited == numberOfRoom)
        {
            winPanel.SetActive(true);
            Debug.Log("Win");
        }
    }
}
