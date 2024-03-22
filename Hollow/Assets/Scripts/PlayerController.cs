using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerHealthController healthController;
    public GameObject attackPoint;

    private Animator animator;
    private int maxHealth = 12;
    private int currentHealth;
    private ExperienceController experienceController;
    private int maxExperience;
    private int currentExperience;
    private FadingText LevelUpMsg;
    private SpriteRenderer spriteRenderer;
    private Vector2 movementDirection;
    private float currentSpeed;
    private float lastHorizontalInput;
    private float elapsedTime;
    private float lastHealing;
    public static int currentLevel;


    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentSpeed = 1.5f; // Initialize speed

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
        maxExperience = experienceController.maxExperience;
        Debug.Log("Max XP: " + maxExperience);
        // Set up level up message
        LevelUpMsg = GameObject.Find("LevelUpMessage").GetComponent<FadingText>();
        currentLevel = 0;
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

        // Timer system
        elapsedTime += Time.deltaTime;
        if (elapsedTime - lastHealing >= 10.0)
        {
            PlayerHealing();
            lastHealing = elapsedTime;
        }
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
            AudioManager.instance.PlaySoundEffects("PlayerDead");
            AudioManager.instance.bgmSource.Stop();
            SceneManager.LoadScene("DeathScene");
        }
    }

    public void PlayerHealing()
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
            AudioManager.instance.PlaySoundEffects("GainXp");
            LevelUp();
        }
        
    }

    public void LevelUp()
    {
        // each higher level gives player one more heart
        healthController.AddHeart();
        //maxHealth = maxHealth + 2;
        healthController.SetHealth(healthController.currentHealth);

        currentLevel++;

        experienceController.IncresedExperience();
        maxExperience = experienceController.maxExperience;
        // Debug.Log("Max XP: " + maxExperience);
        experienceController.SetExperience(0);
        currentExperience = 0;

        // Show the level up message
        LevelUpMsg.IsFadingIn(true);
        
        if (currentLevel >= 2)
        {
            this.gameObject.GetComponent<PlayerCombat>().ActivateFireball();
        }
        if (currentLevel >= 4)
        {
            this.gameObject.GetComponent<PlayerCombat>().ActivateBlueFire();
        }
        
        if (currentLevel >= 6)
        {
            int num = Random.Range(0, 4);
            if (num == 0)
            {
                if (this.gameObject.GetComponent<PlayerCombat>().maxFireBalls < 5)
                {
                    this.gameObject.GetComponent<PlayerCombat>().maxFireBalls++;
                }
                else
                {
                    this.gameObject.GetComponent<PlayerCombat>().maxFireBalls = 8;
                }
            }else if (num == 1)
            {
                if (this.gameObject.GetComponent<PlayerCombat>().blueFireInterval > 0.8f)
                {
                    this.gameObject.GetComponent<PlayerCombat>().blueFireInterval -= 0.1f;
                }
                else 
                {
                    this.gameObject.GetComponent<PlayerCombat>().blueFireInterval = 0.5f;
                }
            }
            else if (num == 2)
            {
                this.gameObject.GetComponent<PlayerCombat>().attackRange += 0.1f;
            }
            else
            {
                if (this.gameObject.GetComponent<PlayerCombat>().blueFireInterval > 0.1f)
                {
                    this.gameObject.GetComponent<PlayerCombat>().attackInterval -= 0.1f;
                }
                else
                {
                    healthController.SetHealth(healthController.maxHealth);
                    currentHealth = maxHealth;
                }

            }
        }

    }
}
