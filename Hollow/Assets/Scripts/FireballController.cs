using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject playerObject;
    [SerializeField] public float speed = 5f;
    [SerializeField] public float radius = 1.0f;

    [SerializeField] public int fireballDamage = 20;

    private Vector3 zAxis = new Vector3(0, 0, 1);

    private float angle;

    void Start()
    {
        playerObject = GameObject.Find("Satyr");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        angle += speed * Time.deltaTime;
        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        this.gameObject.transform.position = playerObject.transform.position + new Vector3(offset.x, offset.y, playerObject.transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ("Enemy" == other.tag)
        {
            if (other != null && other.GetComponent<MobController>() != null)
            {
                other.GetComponent<MobController>().TakeDamage(fireballDamage);
            }
        }
    }
}
