using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceController : MonoBehaviour
{
    public static ExperienceController Instance;
    public delegate void ExperienceChangeHandler(int amount);
    public event ExperienceChangeHandler OnExperienceChange;
    // set max to 1000, gain 100 XP eveytime player kills one enemy
    public int maxExperience = 1000;
    [SerializeField] public int experience;
    [SerializeField] public int currentExperience;
    [SerializeField] public Image experienceBar;
    [SerializeField] public Sprite empty;
    [SerializeField] public Sprite one;
    [SerializeField] public Sprite two;
    [SerializeField] public Sprite three;
    [SerializeField] public Sprite four;
    [SerializeField] public Sprite five;
    [SerializeField] public Sprite six;
    [SerializeField] public Sprite seven;
    [SerializeField] public Sprite eight;
    [SerializeField] public Sprite nice;
    [SerializeField] public Sprite full;

    // Singleton check, making sure there is only one experience mamager
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Everytime when player level up, 200 more XP is needed to reach the next level
    public void IncresedExperience()
    {
        maxExperience += 200;
        Debug.Log("Ah! Max XP: " + maxExperience);
    }
    public void SetExperience(int experience)
    {
        currentExperience = experience;
        if(currentExperience == 0)
        {
            experienceBar.sprite = empty;
        }
        else if(currentExperience >= maxExperience)
        {
            experienceBar.sprite = full;
        }
        else if(currentExperience >= 0.9 * maxExperience)
        {
            experienceBar.sprite = nice;
        }
        else if(currentExperience >= 0.8 * maxExperience)
        {
            experienceBar.sprite = eight;
        }
        else if(currentExperience >= 0.7 * maxExperience)
        {
            experienceBar.sprite = seven;
        }
        else if(currentExperience >= 0.6 * maxExperience)
        {
            experienceBar.sprite = six;
        }
        else if(currentExperience >= 0.5 * maxExperience)
        {
            experienceBar.sprite = five;
        }
        else if(currentExperience >= 0.4 * maxExperience)
        {
            experienceBar.sprite = four;
        }
        else if(currentExperience >= 0.3 * maxExperience)
        {
            experienceBar.sprite = three;
        }
        else if(currentExperience >= 0.2 * maxExperience)
        {
            experienceBar.sprite = two;
        }
        else if(currentExperience >= 0.1 * maxExperience)
        {
            experienceBar.sprite = one;
        }
        
    }
}
