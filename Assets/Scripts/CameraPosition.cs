using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform player;  // Referencia al transform del jugador

    public float smoothness = 5f;  // Controla la suavidad del seguimiento

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
