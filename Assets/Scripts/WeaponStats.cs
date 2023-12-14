using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa las estadísticas del arma.
/// </summary>
public class WeaponStats : MonoBehaviour
{
    /// <summary>
    /// Daño base del arma.
    /// </summary>
    [SerializeField] float damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Obtiene el daño actual del arma.
    /// </summary>
    /// <returns>Daño del arma.</returns>
    public float getDamage()
    {
        return damage;
    }
    /// <summary>
    /// Establece el daño del arma.
    /// </summary>
    /// <param name="t_damage">Nuevo valor de daño del arma.</param>
    public void setDamage(float t_damage)
    {
        damage = t_damage;
    }
    /// <summary>
    /// Incrementa el daño del arma en una cantidad adicional.
    /// </summary>
    /// <param name="t_damage">Cantidad adicional de daño.</param>
    public void increaseDamage(float t_damage)
    {
        damage += t_damage;
    }
}
