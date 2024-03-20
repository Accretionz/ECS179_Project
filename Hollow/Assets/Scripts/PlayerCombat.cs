using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator attackPointAnimator;

    [SerializeField] public GameObject attackPoint;
    [SerializeField] public float attackRange = 0.5f;

    [SerializeField] public float attackInterval = 2.0f;
    private float currentTime = 0.0f;
    [SerializeField] public int attackDamage = 100;
    [SerializeField] public GameObject fireballPrefab;
    [SerializeField] public bool fireballActive = true;
    [SerializeField] public int maxFireBalls = 2;
    private int numFireballs = 0;
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
            if (fireballActive)
            {
                if (numFireballs < maxFireBalls)
                {
                    numFireballs += 1;
                    var playerPosition = this.gameObject.transform.position;
                    Instantiate(fireballPrefab, new Vector3(playerPosition.x, playerPosition.y + 1, playerPosition.z), Quaternion.identity);
                }
            } 
        }
    }

    void Attack()
    {
        // Play attack animation
        attackPointAnimator.SetTrigger("Attack");
        // Detect enemies in range of attack

        AudioManager.instance.PlaySoundEffects("PlayerAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, enemyLayers);
        // Damage them

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<MobController>().TakeDamage(attackDamage);
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
