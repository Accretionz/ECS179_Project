using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration = 3f; // Adjust this for attack phase
    [SerializeField] private float maxSpeed = 4f; // Adjust this for sustain phase
    [SerializeField] private float releaseSpeed = 3f; // Adjust this for release phase

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementDirection;
    private float currentSpeed;
    private float lastHorizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = 3f; // Initialize speed
    }

    void Update()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (horizontalInput != 0f)
        {
            lastHorizontalInput = horizontalInput;
        }

        spriteRenderer.flipX = lastHorizontalInput < 0f;
    }

    void FixedUpdate()
    {
        // Apply ADSR movement
        if (movementDirection.magnitude > 0f)
        {
            // Attack phase (acceleration)
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            // Release phase (gradual speed reduction)
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, releaseSpeed * Time.fixedDeltaTime);
        }

        // Apply movement
        rb.velocity = movementDirection * currentSpeed;
    }
}
