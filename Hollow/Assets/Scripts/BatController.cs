using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private NavMeshAgent agent;
    [SerializeField]
    private Animator animate;
    [SerializeField]
    private float maxDistance;
    [SerializeField]
    private float timeSinceAttack;
    [SerializeField]
    private GameObject projectile;

    private GameObject player;
    private float Timer = 5.0f;
    private int health = 1;
    private float timeTilDeath = 15.0f;
    private float deathTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Satyr");
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Vector2.Distance(player.transform.position, transform.position) >= maxDistance)
        {
            animate.SetBool("isAttacking", false);
            gameObject.GetComponent<NavMeshAgent>().isStopped = false;
            this.agent.SetDestination(player.transform.position);
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            Timer += Time.deltaTime;
            if (Timer > timeSinceAttack)
            {
                animate.SetBool("isAttacking", true);
                animate.SetBool("isIdle", true);
                Instantiate(this.projectile, transform.position, Quaternion.identity);
                Timer = 0.0f;
            }
            animate.SetBool("isIdle", false);
        }

        deathTimer += Time.deltaTime;
        if (deathTimer > timeTilDeath)
        {
            Destroy(this.gameObject);
        }
    }
}
