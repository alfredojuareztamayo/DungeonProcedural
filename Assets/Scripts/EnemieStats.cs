using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieStats : MonoBehaviour
{
    public float life;
    public float damage;
    public float maxVel = 2f;
    public float steeringForce = 1f;
    [SerializeField] private float speed = 1.5f;

    public Transform target; // Asigna el transform del Main Character desde el inspector
    public float rotationSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // Obtén la dirección hacia el Main Character
            Vector3 directionToMainCharacter = target.position - transform.position;

            // Calcula la rotación necesaria para mirar hacia el Main Character
            Quaternion lookRotation = Quaternion.LookRotation(directionToMainCharacter, Vector3.up);

            // Aplica la rotación al enemigo
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float t_speed)
    {
        speed = t_speed;
    }

    public void getDamage(float t_damage)
    {
        life -= t_damage;
    }

    public float getLife()
    {
        return life;
    }

    public bool isDeadEnemy()
    {
        if (life <= 0)
        {
            return false;
        }
        return true;
    }

    public void setTarget(Transform t_target)
    {
        target = t_target;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("weapon"))
        {
           
            WeaponStats weaponStats = collision.collider.GetComponent<WeaponStats>();
            float t_damage = weaponStats.getDamage();
            life -= t_damage;
            Debug.Log(life + "-" + " esta es mi vida");
        }
    }
}
