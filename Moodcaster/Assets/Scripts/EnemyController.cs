using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //public enum enemytype = {Small, Big}
    //public EnemyType enemyType;

    public int health = 50;
    public float moveSpeed = 20f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
