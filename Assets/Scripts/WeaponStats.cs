using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Clase que representa las estad�sticas del arma.
/// </summary>
public class WeaponStats : MonoBehaviour
{
    /// <summary>
    /// Da�o base del arma.
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
    /// Obtiene el da�o actual del arma.
    /// </summary>
    /// <returns>Da�o del arma.</returns>
    public float getDamage()
    {
        return damage;
    }
    /// <summary>
    /// Establece el da�o del arma.
    /// </summary>
    /// <param name="t_damage">Nuevo valor de da�o del arma.</param>
    public void setDamage(float t_damage)
    {
        damage = t_damage;
    }
    /// <summary>
    /// Incrementa el da�o del arma en una cantidad adicional.
    /// </summary>
    /// <param name="t_damage">Cantidad adicional de da�o.</param>
    public void increaseDamage(float t_damage)
    {
        damage += t_damage;
    }
}
