using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerHealthController healthController;
    private int maxHealth = 12;
    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementDirection;
    private float currentSpeed;
    private float lastHorizontalInput;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = 3f; // Initialize speed

        if(!rb)
        {
            Debug.LogError("No rigid body detected");
        }

        healthController = GameObject.Find("HealthBar").GetComponent<PlayerHealthController>();
        healthController.SetHealth(maxHealth);
        currentHealth = maxHealth;
       
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (horizontalInput != 0f)
        {
            lastHorizontalInput = horizontalInput;
        }

        spriteRenderer.flipX = lastHorizontalInput < 0f;

        rb.velocity = movementDirection * currentSpeed;
        

    }

    // if enemy touches player, lose heart
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            currentHealth--;
            if(currentHealth <= 0)
            {
                currentHealth = 0;
            }
            healthController.SetHealth(currentHealth);
            checkDeath();
        }
    }

    public void checkDeath()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

    
}
