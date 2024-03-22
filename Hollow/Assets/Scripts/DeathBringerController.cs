using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DeathBringerController : MobController
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private float attackInterval;
    private GameObject player;
    private float Timer = 5.0f;

    void Start()
    {
        player = GameObject.Find("Satyr");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Terrain"); 
        foreach (GameObject g in  gameObjects)
        {
            Physics2D.IgnoreCollision(g.GetComponent<Collider2D>(), GetComponent<BoxCollider2D>());
        }
    }

    void Update()
    {
        Timer += Time.deltaTime;
        Vector2 enemyToPlayer = player.transform.position - transform.position;
        Vector2 targetDirection = enemyToPlayer.normalized;
        if (targetDirection.x > 0)
        {
            // Using this because it also flips the colliders.
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        this.agent.SetDestination(player.transform.position);
        // Attack if player is close
        if (Vector2.Distance(player.transform.position, transform.position) <= 20 && Timer > attackInterval)
        {
            AudioManager.instance.PlaySoundEffects("BossAttack");
            animator.SetTrigger("Attack");
            Timer = 0.0f;
        }
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
        Debug.Log("Boss died!");
        AudioManager.instance.PlaySoundEffects("BossDead");
        animator.SetBool("isDead", true);
        player.GetComponent<PlayerController>().ExperienceChange(500);
        Destroy(gameObject, 1.15f);
    }
}
