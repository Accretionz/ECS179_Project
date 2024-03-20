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
    //     currentHealth -= damage;
    //     animator.SetTrigger("Damaged");
    //     if (currentHealth <= 0)
    //     {
    //         Die();
    //     }
    }

    public virtual void Die()
    {
        // Debug.Log("Enemey died!");
        // animator.SetBool("isDead", true);
        // //player.GetComponent<PlayerController>().ExperienceChange(100);
        // Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0)[0].clip.length);

        // // Destroy(gameObject);
    }   

}
