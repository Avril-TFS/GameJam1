using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int enemyDamage = 30;
    public int playerDamage = 10;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerController player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                player.Damage(playerDamage);
                Debug.Log("You hit yourself with a Fireball. you took " + playerDamage + "damage");
            }
        }
        else if (col.CompareTag("Enemy"))
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(enemyDamage);
            }
        }
    }
}
