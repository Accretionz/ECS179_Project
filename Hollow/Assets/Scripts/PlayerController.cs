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
    public GameObject attackPoint;

    private Animator animator;
    private int maxHealth = 12;
    private int currentHealth;
    private ExperienceController experienceController;
    private int maxExperience = 1000;
    private int currentExperience;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementDirection;
    private float currentSpeed;
    private float lastHorizontalInput;
    private float elapsedTime;
    private float lastHealing;


    void Awake()
    {
        animator = GetComponent<Animator>();
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

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        animator.SetFloat("speed", Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput)));
        
        if (horizontalInput < 0f && lastHorizontalInput == 0f)
        {
            gameObject.transform.Rotate(new Vector3(0,180,0)); 
        }
        if (lastHorizontalInput < 0f && horizontalInput > 0f) 
        {
            gameObject.transform.Rotate(new Vector3(0,180,0)); 
            // gameObject.transform.localScale(new Vector3(1,1,1));

        }
        if (lastHorizontalInput > 0f && horizontalInput < 0f)
        {
            gameObject.transform.Rotate(new Vector3(0,180,0)); 
            // gameObject.transform.localScale(new Vector3(-1,1,1));
        }
        
        if (horizontalInput != 0f)
        {
            lastHorizontalInput = horizontalInput;
        }

        // spriteRenderer.flipX = lastHorizontalInput < 0f;

        rb.velocity = movementDirection * currentSpeed;
<<<<<<< HEAD
=======
        

        // set up experience bar for player
        experienceController = GameObject.Find("ExperienceBar").GetComponent<ExperienceController>();
        experienceController.SetExperience(0);
        currentExperience = 0;

        // Timer system
        elapsedTime += Time.deltaTime;
        if (elapsedTime - lastHealing >= 15.0)
        {
            playerHealing();
            lastHealing = elapsedTime;
        }
>>>>>>> origin/master
    }

    // if enemy touches player, lose heart
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   
            currentHealth -= 1 + timer.damageIncrease;
            // Debug.Log("Damage taken: " + (int)(1.0 + timer.damageIncrease));
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

    public void playerHealing()
    {
        currentHealth += 1;
        healthController.SetHealth(currentHealth);
    }

    public void ExperienceChange(int experience)
    {
        currentExperience += experience;
        Debug.Log("current Experience: " + currentExperience);
        experienceController.SetExperience(currentExperience);
        if(currentExperience >= maxExperience)
        {
            LevelUp();
        }
        
    }

    public void LevelUp()
    {
        // each higher level gives player one more heart
        healthController.AddHeart();
        //currentHealth = maxHealth;

        // currentLevel++
        experienceController.SetExperience(0);
        currentExperience = 0;
    }
}
