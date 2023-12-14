using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que define el comportamiento de un cofre en el juego.
/// </summary>
public class ChestBehaviour : MonoBehaviour
{
    /// <summary>
    /// Referencia al objeto del jugador.
    /// </summary>
    private GameObject player;
    /// <summary>
    /// Arreglo de clips de sonido para el cofre.
    /// </summary>
    public AudioClip[] audios;
    /// <summary>
    /// Fuente de audio para reproducir sonidos.
    /// </summary>
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // checkDistance(); 
    }

    /// <summary>
    /// Verifica la distancia entre el jugador y el cofre para realizar acciones.
    /// </summary>
    void checkDistance()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log("La distancia es: "+ dist);
        if(dist < 0.5f && Input.GetKey(KeyCode.F))
        {
            PlayerStat playerStat = player.GetComponent<PlayerStat>();
            int luck = Random.Range(0, 3);
            switch(luck)
            {
                case 0:
                    playerStat.increaseLife(10f);
                    audioSource.clip = audios[0];
                    break;
                case 1:
                    playerStat.damagePlayer(10f);
                    audioSource.clip = audios[1];
                    break;
                case 2:
                    playerStat.increaseLife(5f);
                    audioSource.clip = audios[0];
                    break;

            }
        }
        
    }
    /// <summary>
    /// Método que se llama cuando un objeto colisiona con el cofre.
    /// </summary>
    /// <param name="other">Collider del objeto que colisionó.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerStat playerStat = player.GetComponent<PlayerStat>();
            int luck = Random.Range(0, 3);
            switch (luck)
            {
                case 0:
                    playerStat.increaseLife(10f);
                    audioSource.clip = audios[0];
                    break;
                case 1:
                    playerStat.damagePlayer(10f);
                    audioSource.clip = audios[1];
                    break;
                case 2:
                    playerStat.increaseLife(5f);
                    audioSource.clip = audios[0];
                    break;

            }
            audioSource.Play();
            StartCoroutine(destroyChest());
            //Destroy(gameObject);
        }
    }
    /// <summary>
    /// Rutina que destruye el cofre después de un cierto tiempo.
    /// </summary>
    IEnumerator destroyChest()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
