using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Animator animator;

    public virtual void TakeDamage(int damage)
    {
    }
    public virtual void Die()
    {
    }
}
