using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Clase que controla la posici�n de la c�mara.
/// </summary>
public class CameraPosition : MonoBehaviour
{
    // <summary>
    /// Referencia al transform del jugador.
    /// </summary>
    public Transform player;  // Referencia al transform del jugador

    /// <summary>
    /// Controla la suavidad del seguimiento.
    /// </summary>
    public float smoothness = 5f;  // Controla la suavidad del seguimiento

    /// <summary>
    /// M�todo que se llama al inicio.
    /// </summary>
    private void Start()
    {
        transform.position = new Vector3(player.position.x,transform.position.y,player.position.z);

    }
    /// <summary>
    /// M�todo que se llama en cada fixed update.
    /// </summary>
    private void FixedUpdate()
    {
        if (player != null)
        {
            follow();
        }
        else
        {
            Debug.LogWarning("�No se ha asignado el jugador!");
        }
    }
    /// <summary>
    /// M�todo que sigue al jugador ajustando la posici�n de la c�mara.
    /// </summary>
    void follow()
    {
        // Obtener la posici�n actual de la c�mara
        Vector3 newPos = transform.position;

        // Solo seguir en los ejes x y z
        newPos.x = Mathf.Lerp(transform.position.x, player.position.x, smoothness * Time.deltaTime);
        newPos.z = Mathf.Lerp(transform.position.z, player.position.z, smoothness * Time.deltaTime);

        // Aplicar la nueva posici�n a la c�mara
        transform.position = newPos;
    }
}
