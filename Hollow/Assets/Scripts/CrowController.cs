using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowController : MobController
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private NavMeshAgent agent;
    
    private Rigidbody2D rigidBody;
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Satyr");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update() {
        Vector2 enemyToPlayer = player.transform.position - transform.position;
        Vector2 targetDirection = enemyToPlayer.normalized;
        if (targetDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        this.agent.SetDestination(player.transform.position);
    }

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Damaged");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        Debug.Log("Enemy died!");
        animator.SetBool("isDead", true);
        player.GetComponent<PlayerController>().ExperienceChange(100);
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
    }   
}
