using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ChestPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementDirection;
    private float currentSpeed;
    private float lastHorizontalInput;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = 1.5f; // Initialize speed

        if (!rb)
        {
            Debug.LogError("No rigid body detected");
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        animator.SetFloat("speed", Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput)));

        if (horizontalInput < 0f && lastHorizontalInput == 0f)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }
        if (lastHorizontalInput < 0f && horizontalInput > 0f)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));

        }
        if (lastHorizontalInput > 0f && horizontalInput < 0f)
        {
            gameObject.transform.Rotate(new Vector3(0, 180, 0));
        }

        if (horizontalInput != 0f)
        {
            lastHorizontalInput = horizontalInput;
        }

        // spriteRenderer.flipX = lastHorizontalInput < 0f;

        rb.velocity = movementDirection * currentSpeed;
    }

    // When player touch the teleport
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            canOpen = true;
        }
        */
        if (collision.gameObject.tag == "Teleport")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (collision.gameObject.tag == "Teleport2")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }
}
