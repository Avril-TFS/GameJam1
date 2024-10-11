using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public enum enemytype = {Small, Big}
    //public EnemyType enemyType;

    public int health = 50;
    public float moveSpeed = 10f;

    public Transform player;

    public float detectionRange = 20f;
    private bool isPlayerClose = false;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);  // Adjust rotation speed as needed

        if (distanceToPlayer < detectionRange)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }

        //CheckPlayerDistance();
    }
    /*   void FixedUpdate()
       {
           if (isPlayerClose)
           {
               FacePlayer();
               ChasePlayer();

           }
       }
       void CheckPlayerDistance()
       {
           float distanceToPlayer = Vector3.Distance(transform.position, player.position);

           isPlayerClose = distanceToPlayer <= detectionRange;
       }
       void FacePlayer()
       {
           Vector3 directionToPlayer = (player.position - transform.position).normalized;

           Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToPlayer.x, 0, directionToPlayer.z));

           transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
       }
       void ChasePlayer()
       {
           Vector3 directionToPlayer = (player.position - transform.position).normalized;

           Vector3 moveTo = new Vector3(directionToPlayer.x, 0, directionToPlayer.z);

           transform.position += moveTo * moveSpeed * Time.deltaTime;
       }*/
    public void TakeDamage(int amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, 100);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
