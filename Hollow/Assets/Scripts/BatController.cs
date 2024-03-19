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

    private GameObject player;
    private float Timer = 0.0f;
    private int health = 1;

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
            animate.SetBool("isAttacking", true);
            Timer += Time.deltaTime;
            animate.SetFloat("timeSinceAttack", Timer);
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            if (Timer > timeSinceAttack)
            {
                Timer = 0.0f;
            }
        }
    }
}
