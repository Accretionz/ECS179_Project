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


    private Rigidbody2D rigidBody;
    private GameObject player;
    private float timeTilDeath = 5.0f;
    private float Timer = 0.0f;

    void Start()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
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
        Timer += Time.deltaTime;
        if (Timer > timeTilDeath)
        {
            Destroy(this.gameObject);
        }
        //this.agent.SetDestination(new Vector3(Random.Range(-5f, 5f), this.gameObject.transform.position.y, 0));
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
