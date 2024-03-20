using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Animator animator;

    public virtual void TakeDamage(int damage)
    {
    }
    public virtual void Die()
    {
       
    }

    private void rotate()
    {
        /*
        Vector2 testPlayer = new Vector2(0, 0);
        Vector2 enemyToPlayer = testPlayer - (Vector2)transform.position;
        Vector2 targetDirection = enemyToPlayer.normalized; 
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rigidBody.SetRotation(rotation);*/
    }

    private void move()
    {
        /*
        Vector2 enemyToPlayer = player.transform.position - transform.position;
        Vector2 targetDirection = enemyToPlayer.normalized;
        rigidBody.velocity = targetDirection * speed;
        if (targetDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }*/
    }
}
