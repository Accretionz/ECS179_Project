using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 20.0f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerHealthController healthController;
    private int maxHealth = 12;
    private int currentHealth;


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");

        Debug.Log("X: " + moveInput.x);
        Debug.Log("Y: " + moveInput.y);
        Debug.Log("Here");
       
        moveInput.Normalize();

        rb.velocity = moveInput * speed;
        

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
