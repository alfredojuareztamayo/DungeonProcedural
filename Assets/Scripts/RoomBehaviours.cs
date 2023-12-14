using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBehaviours : MonoBehaviour
{

    public GameObject[] walls; //up,down,right,left
    public GameObject[] doors; //up,down,right,left
    // Start is called before the first frame update
   

    //si recibe como verdadero en el estado de up,down,right,left significa que esta puerta esta abierta y por ende se va a activar el gameobject
    //y el de la pared se va a apagar setActive(state) :)
   public void updateRooms(bool[] state)
    {
        for(int i = 0; i < state.Length; i++) 
        {
            doors[i].SetActive(state[i]);
            walls[i].SetActive(!state[i]);
        }
    }
}
