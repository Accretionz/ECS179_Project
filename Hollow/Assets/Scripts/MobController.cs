using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    private Rigidbody2D rigidBody;
    private float TimeSinceChecked = 0.0f;
    private float Timer = 0.0f;
    private int groupID = 1;
    private float lifespan = 0.0f;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); 
        this.lifespan = Random.Range(10.0f, 40.0f);
    }

    // Despawn pikimini. Unsubscribe before destroying.
    private void Despawn()
    {
        //this.publisherManager.UnsubscribeFromGroup(groupID, OnMoveMessage);
        Destroy(this.gameObject);
    }

    // Watch when time greater than throttle and also keep track of lifespan to despawn.
    public void Update()
    {
        /*
        TimeSinceChecked += Time.deltaTime;
        Timer += Time.deltaTime;
        if (TimeSinceChecked >= 0.5f)
        {
            TimeSinceChecked = 0.0f;
        }
        if (Timer >= lifespan)
        {
            Despawn();
        }*/
    }

    private void FixedUpdate() {
        rotate();
        move();
    }


    private void updateTargetDirection()
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
        Vector2 testPlayer = new Vector2(0, 0);
        Vector2 enemyToPlayer = testPlayer - (Vector2)transform.position;
        Vector2 targetDirection = enemyToPlayer.normalized;
        rigidBody.velocity = targetDirection * speed;
        if (targetDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
    }
}
