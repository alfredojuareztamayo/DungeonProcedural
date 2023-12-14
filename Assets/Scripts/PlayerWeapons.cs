using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que gestiona las armas del jugador.
/// </summary>
public class PlayerWeapons : MonoBehaviour
{
  
    /// /// <summary>
    /// Arreglo de prefabs de armas que el jugador puede tener.
    /// </summary>
    public GameObject[] weaponsPrefab;
    /// <summary>
    /// Arreglo de colliders asociados a las armas.
    /// </summary>
    [SerializeField] GameObject[] colliders;
    /// <summary>
    /// Contador que lleva el seguimiento de la actual arma equipada.
    /// </summary>
    int weaponCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        changeWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Cambia el arma equipada por la siguiente en la lista.
    /// </summary>
    public void changeWeapon()
    {

        //weaponsPrefab[weaponCount].SetActive(true);
        for(int i = 0; i < weaponsPrefab.Length; i++)
        {
            if(i == weaponCount)
            {
                weaponsPrefab[i].SetActive(true);
                colliders[i].SetActive(true);
                break;
            }
            else
            {
                weaponsPrefab[i].SetActive(false);
                colliders[i].SetActive(false);
            }
        }
        weaponCount++;
    }
}
