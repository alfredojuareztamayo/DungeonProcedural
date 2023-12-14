using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase que actualiza el arma del jugador al entrar en contacto con este objeto.
/// </summary>
public class UpdateWeapon : MonoBehaviour
{
    /// <summary>
    /// Clip de audio asociado a la actualizaci�n del arma.
    /// </summary>
    public AudioClip AudioClip;
    /// <summary>
    /// Fuente de audio para reproducir sonidos.
    /// </summary>
    AudioSource audioSource;
    /// <summary>
    /// M�todo que se llama al inicio.
    /// </summary>
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    /// <summary>
    /// M�todo que se llama cuando un objeto colisiona con este objeto.
    /// </summary>
    /// <param name="other">Collider del objeto que colision�.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerWeapons playerWeapons = other.GetComponent<PlayerWeapons>();
            playerWeapons.changeWeapon();
            StartCoroutine(audioUpdate());
        }
    }
    /// <summary>
    /// Rutina que actualiza el audio y destruye el objeto despu�s de un cierto tiempo.
    /// </summary>
    IEnumerator audioUpdate()
    {
        audioSource.clip = AudioClip;
        audioSource.Play();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
