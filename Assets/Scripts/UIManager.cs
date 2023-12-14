using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Clase que gestiona la interfaz de usuario (UI) del juego.
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Referencia al objeto del jugador.
    /// </summary>
    public GameObject player;
    /// <summary>
    /// Referencia al objeto que genera las habitaciones.
    /// </summary>
    public GameObject GeneratorRooms;
    /// <summary>
    /// Número total de habitaciones en el juego.
    /// </summary>
    public int roomsTotal;
    /// <summary>
    /// Barra de desplazamiento que representa la vida del jugador.
    /// </summary>
    public Scrollbar ScrollbarLife;
    /// <summary>
    /// Texto que muestra la cantidad de habitaciones visitadas.
    /// </summary>
    public TMP_Text textRooms;
    /// <summary>
    /// Referencia a las estadísticas del jugador.
    /// </summary>
    PlayerStat playerstat;
    /// <summary>
    /// Vida actual del jugador.
    /// </summary>
    float lifePlayer;
    /// <summary>
    /// Vida máxima del jugador.
    /// </summary>
    float maxLife;
    /// <summary>
    /// Método que se llama al inicio.
    /// </summary>
    private void Start()
    {
        playerstat = player.GetComponent<PlayerStat>();
        lifePlayer = playerstat.getLife();
        maxLife = playerstat.getMaxLife();
        roomsTotal = GeneratorRooms.transform.childCount;
    }
    private void Update()
    {
        lifePlayer = playerstat.getLife();
        setScrollbar();
        getTextRooms();
    }
    /// <summary>
    /// Ajusta la barra de desplazamiento de acuerdo a la vida del jugador.
    /// </summary>
    void setScrollbar()
    {
        ScrollbarLife.value = 0;
        ScrollbarLife.size = (lifePlayer/maxLife);
    }
    /// <summary>
    /// Actualiza el texto que muestra la cantidad de habitaciones visitadas.
    /// </summary>
    void getTextRooms()
    {
        roomsTotal = GeneratorRooms.transform.childCount;
        int roomsVisited = playerstat.getRoomsVisited();

        textRooms.text = roomsVisited.ToString() + "/" + roomsTotal.ToString();
    }
}
