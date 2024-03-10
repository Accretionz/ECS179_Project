using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public int maxHealth = 12; // 6 hearts
    [SerializeField] public int currentHealth;
    [SerializeField] public Image[] hearts;
    [SerializeField] public Sprite fullHearts;
    [SerializeField] public Sprite halfHearts;
    [SerializeField] public Sprite emptyHeats;
    
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


}