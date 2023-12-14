using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa las estad�sticas del jugador.
/// </summary>
public class PlayerStat : MonoBehaviour
{/// <summary>
 /// Vida actual del jugador.
 /// </summary>
    [SerializeField] float life = 100f;
    /// <summary>
    /// Velocidad del jugador.
    /// </summary>
    [SerializeField] float speed = 1.5f;
    /// <summary>
    /// Indica si el jugador est� muerto.
    /// </summary>
    [SerializeField] bool deadPlayer = false;
    /// <summary>
    /// N�mero de habitaciones visitadas por el jugador.
    /// </summary>
    [SerializeField] int roomsVisited;

    /// <summary>
    /// Vida m�xima del jugador.
    /// </summary>
    float maxLife = 100f;
    


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       // stillStanding();
        backMaxLife();
    }
    /// <summary>
    /// Obtiene la velocidad actual del jugador.
    /// </summary>
    /// <returns>Velocidad del jugador.</returns>
    public float getSpeed()
    {
        return speed;
    }

    /// <summary>
    /// Establece la velocidad del jugador.
    /// </summary>
    /// <param name="t_speed">Nueva velocidad del jugador.</param>
    public void setSpeed(float t_speed)
    {
        speed = t_speed;
    }
    /// <summary>
    /// Reduce la vida del jugador seg�n el da�o recibido.
    /// </summary>
    /// <param name="t_damage">Cantidad de da�o recibido.</param>
    public void damagePlayer(float t_damage)
    {
        life -= t_damage;
    }
    /// <summary>
    /// Obtiene la vida actual del jugador.
    /// </summary>
    /// <returns>Vida actual del jugador.</returns>
    public float getLife()
    {
        return life;
    }
    /// <summary>
    /// Obtiene la vida m�xima del jugador.
    /// </summary>
    /// <returns>Vida m�xima del jugador.</returns>
    public float getMaxLife()
    {
        return maxLife;
    }
    /// <summary>
    /// Aumenta la vida del jugador en una cantidad adicional.
    /// </summary>
    /// <param name="extra">Cantidad adicional de vida.</param>
    public void increaseLife(float extra)
    {
        life += extra;
    }
    /// <summary>
    /// Obtiene el n�mero de habitaciones visitadas por el jugador.
    /// </summary>
    /// <returns>N�mero de habitaciones visitadas.</returns>
    public int getRoomsVisited()
    {
        return roomsVisited;
    }
    /// <summary>
    /// Incrementa el contador de habitaciones visitadas.
    /// </summary>
    public void increseRooms()
    {
        roomsVisited++;
    }
    /// <summary>
    /// Ajusta la vida del jugador para que no exceda la vida m�xima.
    /// </summary>
    void backMaxLife()
    {
        if(life > maxLife)
        {
            life = maxLife;
        }
    }
    /// <summary>
    /// Verifica si el jugador sigue en pie (con vida).
    /// </summary>
    /// <returns>True si el jugador est� en pie, False si no.</returns>
    public bool stillStanding()
    {
        if(life <= 0) 
        {
            return false;
        }
        return true;
    }
}
