using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class BlueFireController : MonoBehaviour
{
    [SerializeField] public float speed = 2.0f;
    [SerializeField] public int blueFireDamage = 20;

    void Awake()
    {
        this.GetComponent<Rigidbody2D>().velocity = transform.right * -speed;
        Destroy(gameObject, 15.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ("Enemy" == other.tag)
        {
            if (other != null && other.GetComponent<MobController>() != null)
            {
                other.GetComponent<MobController>().TakeDamage(blueFireDamage);
            }
        }
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if(collision.gameObject.tag != "Enemy")
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
