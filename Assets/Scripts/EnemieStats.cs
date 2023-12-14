using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieStats : MonoBehaviour
{
    public float life;
    public float damage;
    public float maxVel = 2f;
    public float steeringForce = 1f;
    public bool isAlive = true;
    private List<GameObject> food = new List<GameObject>();
    private List<GameObject> poison = new List<GameObject>();

    private int[] dna = new int[2];

    Animator animator;
    Rigidbody rb;
    [SerializeField] private float speed = 0.2f;

    public Transform target; // Asigna el transform del Main Character desde el inspector
    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        GameObject[] foodArray = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject foodObject in foodArray)
        {
            food.Add(foodObject);
        }
        dna[0] = Random.Range(-5, 6);
        dna[1] = Random.Range(-5, 6);

    }

    private void FixedUpdate()
    {
       // behaviour(food, poison);
        //eat(food);
        //eat(poison);

    }
    private Vector3 eat(List<GameObject> temp)
    {

        float record = float.PositiveInfinity;
        GameObject closest = null;
        foreach (GameObject foodObject in temp)
        {
            float dist = Vector3.Distance(transform.position, foodObject.transform.position);
            if (dist < record)
            {
                record = dist;
                closest = foodObject;
            }
        }

        
        if (target == null)
        {
           
            return Vector3.zero;
        }
        if (record < 5)
        {

            temp.Remove(closest);
        }
        else if (record > -1)
        {
          
            return SteeringBehaviours.Seek(transform, target.transform.position);
        }


        return Vector3.zero;
    }


    private void behaviour(List<GameObject> good, List<GameObject> bad)
    {
        Vector3 steerG = eat(good);
        Vector3 steerB = eat(bad);

        steerG *= dna[0];
        steerB *= dna[1];

        //agent.applyForce(steerB);

    }


    // Update is called once per frame
    void Update()
    {
        checkIsAlive();
        if(isAlive)
        {
            lookAtPlayer();
        }
      
       // seekPlayer();
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

    void lookAtPlayer()
    {
        if (target != null)
        {
            // Obtén la dirección hacia el Main Character
            Vector3 directionToMainCharacter = target.position - transform.position;
            // Calcula la rotación necesaria para mirar hacia el Main Character
            Quaternion lookRotation = Quaternion.LookRotation(directionToMainCharacter, Vector3.up);
            // Aplica la rotación al enemigo
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            seekPlayer();
        }
    }

    void seekPlayer()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist < 4)
        {
            if(dist > 1.3f) 
            {
                //rb.velocity = SteeringBehaviours.Seek(transform, target.position);
                animator.SetBool("isWalking", true);
                animator.SetBool("isPunch", false);
                Vector3 direction = target.position - transform.position;
                Vector3 velocity = direction.normalized * speed;
                transform.Translate(velocity * Time.deltaTime);
            }
            else
            {
                animator.SetBool("isWalking", false);
                animator.SetBool("isPunch", true);

            }
            
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
      //  
    }

    public void checkIsAlive()
    {
        if(life<= 0)
        {
            isAlive = false;
            StartCoroutine(isAliveOrDead());
        }
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

    IEnumerator isAliveOrDead()
    {
        
        animator.SetBool("IsDying", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isPunch", false);
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
