using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use InputManager in project setting
public class PlayerMovement : MonoBehaviour
{
    // Movement
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Frame rate dependent
    void Update()
    {
        InputManagement();
    }

    // Frame rate independent
    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    
}
