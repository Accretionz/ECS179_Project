using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator attackPointAnimator;

    [SerializeField] public GameObject attackPoint;
    [SerializeField] public float attackRange = 0.5f;

    [SerializeField] public float attackInterval = 3.0f;
    private float currentTime = 0.0f;
    [SerializeField] public int attackDamage = 100;

    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        attackPointAnimator = attackPoint.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= attackInterval)
        {
            currentTime = 0.0f;
            Attack();
        }
    }

    void Attack()
    {
        // Play attack animation
        attackPointAnimator.SetTrigger("Attack");
        // Detect enemies in range of attack

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayers);
        // Damage them

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<CrowController>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
