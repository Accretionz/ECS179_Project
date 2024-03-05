using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 20.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        if(!rb)
        {
            Debug.LogError("No rigid body detected");
        }
       
    }


    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
       
        moveInput.Normalize();

        rb.velocity = moveInput * speed;
        

    }
}
