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

    public void AddExperience(int amount)
    {
        // ?. safeguard from null
        OnExperienceChange?.Invoke(amount);
    }

    public void SetExperience(int experience)
    {
        currentExperience = experience;
        switch(currentExperience)
        {
            case 0:
                experienceBar.sprite = empty;
                break;
            case 100:
                experienceBar.sprite = one;
                break;
            case 200:
                experienceBar.sprite = two;
                break;
            case 300:
                experienceBar.sprite = three;
                break;
            case 400:
                experienceBar.sprite = four;
                break;
            case 500:
                experienceBar.sprite = five;
                break;
            case 600:
                experienceBar.sprite = six;
                break;
            case 700:
                experienceBar.sprite = seven;
                break;
            case 800:
                experienceBar.sprite = eight;
                break;
            case 900:
                experienceBar.sprite = nice;
                break;
            case 1000:
                experienceBar.sprite = full;
                break;
            default:
                Debug.Log("Error in experience computation!");
                break;
        }
    }
}
