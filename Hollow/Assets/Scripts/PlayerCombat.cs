using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator attackPointAnimator;

    [SerializeField] public GameObject attackPoint;
    [SerializeField] public float attackRange = 0.5f;

    [SerializeField] public float attackInterval = 2.0f;
    [SerializeField] public float blueFireInterval = 1.5f;
    private float defaultAttackTime = 0.0f;
    private float blueFireSpellTime = 0.0f;
    [SerializeField] public int attackDamage = 100;
    [SerializeField] public GameObject blueFirePrefab;
    [SerializeField] public GameObject fireballPrefab;
    [SerializeField] public bool fireballActive = false;
    [SerializeField] public bool blueFireActive = false;
    [SerializeField] public int maxFireBalls = 1;
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
        defaultAttackTime += Time.deltaTime;
        blueFireSpellTime += Time.deltaTime;
        if (defaultAttackTime >= attackInterval)
        {
            defaultAttackTime = 0.0f;
            Attack();
            if (fireballActive)
            {
                if (numFireballs < maxFireBalls)
                {
                    numFireballs += 1;
                    var playerPosition = this.gameObject.transform.position;
                    AudioManager.instance.PlaySoundEffects("FireSpell");
                    Instantiate(fireballPrefab, new Vector3(playerPosition.x, playerPosition.y + 1, playerPosition.z), Quaternion.identity);
                }
            } 
        }
        if (blueFireSpellTime >= blueFireInterval)
        {
            blueFireSpellTime = 0.0f;
            if(blueFireActive)
            {
                BlueFireAttack();
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

    void BlueFireAttack()
    {
        var playerPosition = this.gameObject.transform.position;
        var topRightRotation = Quaternion.AngleAxis(225, Vector3.forward);
        var topLeftRotation = Quaternion.AngleAxis(315, Vector3.forward);
        var bottomLeftRotation = Quaternion.AngleAxis(45, Vector3.forward);
        var bottomRightRotation = Quaternion.AngleAxis(135, Vector3.forward);
        AudioManager.instance.PlaySoundEffects("BlueSpell");
        Instantiate(blueFirePrefab, new Vector3(playerPosition.x + 0.1f, playerPosition.y + 0.1f, playerPosition.z), topRightRotation);
        Instantiate(blueFirePrefab, new Vector3(playerPosition.x - 0.1f, playerPosition.y + 0.1f, playerPosition.z), topLeftRotation);
        Instantiate(blueFirePrefab, new Vector3(playerPosition.x + 0.1f, playerPosition.y - 0.1f, playerPosition.z), bottomRightRotation);
        Instantiate(blueFirePrefab, new Vector3(playerPosition.x - 0.1f, playerPosition.y - 0.1f, playerPosition.z), bottomLeftRotation);
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }

    public void ActivateFireball()
    {
        fireballActive = true;
    }

    public void ActivateBlueFire()
    {
        blueFireActive = true;
    }
}
