using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrowController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Animator animate;

    private GameObject player;
    private float timeTilDeath = 5.0f;
    private float Timer = 0.0f;
    private int health = 1;

    void Start()
    {
        player = GameObject.Find("Satyr");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
        //this.agent.SetDestination(new Vector3(Random.Range(-5f, 5f), this.gameObject.transform.position.y, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Satyr") ;
        {
            health -= 1;
            if (health <= 0)
            {
                animate.SetBool("isDead", true);
                // Drop something.
                Destroy(this.gameObject, 0.55f);
            }
        }
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
