using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MobController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    public int maxHealth = 50;
    int currentHealth;
    private Rigidbody2D rigidBody;
    private GameObject player;
    private float timeTilDeath = 15.0f;
    private float Timer = 0.0f;

    private Animator animator;

    void Start()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
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
        Timer += Time.deltaTime;
        if (Timer > timeTilDeath)
        {
            Destroy(this.gameObject);
        }
        //this.agent.SetDestination(new Vector3(Random.Range(-5f, 5f), this.gameObject.transform.position.y, 0));
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Damaged");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemey died!");
        animator.SetBool("isDead", true);
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // Destroy(gameObject);
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
