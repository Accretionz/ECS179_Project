using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    // each heart is 2 health
    public int maxHealth = 12;
    [SerializeField] public int numOfHeart = 6; // player initially has 6 hearts
    [SerializeField] public int currentHealth;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite fullHearts;
    [SerializeField] public Sprite halfHearts;
    [SerializeField] public Sprite emptyHeats;
    
    void Awake()
    {
        numOfHeart = 6;
    }
    
    // evey time when player level up, it will have one more heart
    public void AddHeart()
    {
        numOfHeart++;
        maxHealth = maxHealth + 2;
    }
    
    public void SetHealth(int health)
    {
        
        currentHealth = health;
        for(int i = 0; i < hearts.Length; i++) 
        {
            if(i * 2 >= currentHealth) //currentHealth <= i * 2
            {
                hearts[i].sprite = emptyHeats;
            }
            else if((i * 2) + 1 == currentHealth)
            {
                hearts[i].sprite = halfHearts;
            }
            else
            {
                hearts[i].sprite = fullHearts;
            }
        }
    }

    void Update()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < numOfHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }


}