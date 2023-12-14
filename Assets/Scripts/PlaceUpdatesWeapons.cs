using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que coloca actualizaciones de armas en posiciones específicas.
/// </summary>
public class PlaceUpdatesWeapons : MonoBehaviour
{
    /// <summary>
    /// Referencia al componente PlayerWeapons.
    /// </summary>
    PlayerWeapons playerWeapons;
    /// <summary>
    /// Número de actualizaciones disponibles.
    /// </summary>
    int numberOfUpdates;
    /// <summary>
    /// Indica si hay actualizaciones disponibles.
    /// </summary>
    bool availableUpdates = true;
    /// <summary>
    /// Prefab de las actualizaciones de armas.
    /// </summary>
    public GameObject updates;
    // Start is called before the first frame update
    /// <summary>
    /// Método que se llama al inicio.
    /// </summary>
    void Start()
    {
        playerWeapons = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeapons>();
        numberOfUpdates = playerWeapons.weaponsPrefab.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        setUpdatePlaces();
    }
    /// <summary>
    /// Coloca las actualizaciones de armas en posiciones específicas.
    /// </summary>
    void setUpdatePlaces()
    {
        if (availableUpdates)
        {
            int numberOfChilds = gameObject.transform.childCount;
           
            for(int i = 1; i< numberOfUpdates + 1; i++)
            {
                int k = Mathf.RoundToInt((numberOfChilds / i) - 10);
                Transform son = gameObject.transform.GetChild(k);
                Instantiate(updates,new Vector3(son.position.x +1f,son.position.y + 0.3f,son.position.z),Quaternion.identity);
            }
            availableUpdates = false;
            
        }
    }
}
