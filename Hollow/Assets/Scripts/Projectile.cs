using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool moveLeft;
    private Rigidbody2D rigidBody;
    private Vector2 moveTowardsPlayer;
    Transform t;

    private GameObject player;

    void Awake()
    {
        t = transform;
        rigidBody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Satyr");
    }

    void Start()
    {
        Vector3 enemyToPlayer = player.transform.position - transform.position;
        moveTowardsPlayer = enemyToPlayer.normalized;
        float angle = Mathf.Atan2(enemyToPlayer.y, enemyToPlayer.x) * Mathf.Rad2Deg - 360;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, 300);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<CircleCollider2D>(), GetComponent<CircleCollider2D>());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = moveTowardsPlayer * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
