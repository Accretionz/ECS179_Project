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
    private ExperienceController experienceController;
    private int maxExperience = 1000;
    private int currentExperience;
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

        // set up health bar for player
        healthController = GameObject.Find("HealthBar").GetComponent<PlayerHealthController>();
        healthController.SetHealth(maxHealth);
        currentHealth = maxHealth;

        // set up experience bar for player
        experienceController = GameObject.Find("ExperienceBar").GetComponent<ExperienceController>();
        experienceController.SetExperience(0);
        currentExperience = 0;
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

    public void ExperienceChange(int experience)
    {
        currentExperience += experience;
        experienceController.SetExperience(currentExperience);
        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }
        
    }

    public void LevelUp()
    {
        // each higher level gives player one more heart
        maxHealth += 2;
        currentHealth = maxHealth;

        // currentLevel++

        currentExperience = 0;
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
}
