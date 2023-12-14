using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetPlacePortal : MonoBehaviour
{
   
    public GameObject portal;
    // Start is called before the first frame update
    /// <summary>
    /// Método que se llama al inicio.
    /// </summary>
    /// 
    public bool availablePortal = true;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        setUpdatePlaces();
    }
    void setUpdatePlaces()
    {
       if(availablePortal)
        {
            int numberOfChilds = gameObject.transform.childCount;

            for (int i = 0; i < numberOfChilds; i++)
            {
                Transform son = gameObject.transform.GetChild(i);
                if (i == numberOfChilds - 1)
                {
                    Instantiate(portal, new Vector3(son.position.x + 1f, son.position.y + 0.3f, son.position.z), Quaternion.identity);
                }

            }

         availablePortal = false;
        }
    }
            
}
