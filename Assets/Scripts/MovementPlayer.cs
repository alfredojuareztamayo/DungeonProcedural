using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// Clase que gestiona el movimiento del jugador.
/// </summary>
public class MovementPlayer : MonoBehaviour
{
    /// <summary>
    /// Velocidad de movimiento del jugador.
    /// </summary>
    public float velocidad;

    /// <summary>
    /// Velocidad de rotación del jugador.
    /// </summary>
    public float rotationSpeed;
    /// <summary>
    /// Indica si el jugador está vivo.
    /// </summary>
    public bool isAlive = true;
    /// <summary>
    /// Referencia al componente Animator.
    /// </summary>
    Animator animator;
    /// <summary>
    /// Referencia a las estadísticas del jugador.
    /// </summary>
    PlayerStat playerStats;
    private void Start()
    {
        playerStats = GetComponent<PlayerStat>();
        velocidad = playerStats.getSpeed();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        MoverPersonaje();
        attackMovement();
        isAlive = playerStats.stillStanding();
    }
    /// <summary>
    /// Método que controla el movimiento del personaje.
    /// </summary>

    void MoverPersonaje()
    {
        if (isAlive)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
            movimiento.Normalize();
            transform.Translate(movimiento * velocidad * Time.deltaTime, Space.World);

            // Rota hacia la dirección del movimiento
            if (movimiento != Vector3.zero)
            {
                // StopCoroutine(sadIdle());
                animator.SetBool("isSad", false);
                animator.SetBool("isWalking", true);
                Quaternion toRotation = Quaternion.LookRotation(movimiento, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isWalking", false);
                // StartCoroutine(sadIdle());
            }
        }
        else
        {
            animator.SetBool("isAttack", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isDead", true);
            //gameOver My friend
        }
    }

    /// <summary>
    /// Rutina que hace que el personaje entre en un estado triste.
    /// </summary>
    IEnumerator sadIdle()
    {
        Debug.Log("si entre");
        yield return new WaitForSeconds(2f);
        animator.SetBool("isSad", true);
    }

    /// <summary>
    /// Método que controla el movimiento de ataque.
    /// </summary>
    void attackMovement()
    {
        if (isAlive)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetBool("isAttack", true);
            }
            if (Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("isAttack", false);
            }
        }
    }



}
