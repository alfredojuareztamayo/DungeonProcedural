using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float velocidad = 1.5f;
    public float rotationSpeed;
   
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        MoverPersonaje();
    }

    void MoverPersonaje()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        movimiento.Normalize();
        transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

        // Rota hacia la dirección del movimiento
        if (movimiento != Vector3.zero)
        {
           
            animator.SetBool("isWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(movimiento, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation,rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
