using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerData; //SO

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Transform attackPoint;
    public LayerMask enemyLayers;
    private float nextAttackTime;
    private bool canAttack;

    private void Start()
    {
        nextAttackTime = 0f;
    }

    private void Update()
    {
        // Limits rate of attack, prevent spamming attack
        if (Time.time >= nextAttackTime)
        {
            canAttack = true;
            nextAttackTime = Time.time + 1.0f / playerData.attackRate;
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (canAttack)
        {
            canAttack = false;
            //Play attack animation
            animator.SetTrigger("SwordRunSlash");

            //Detect enemies in range of attack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(
                attackPoint.position,
                playerData.attackRange,
                enemyLayers
            );

            Debug.Log("hit: " + hitEnemies);

            // Damage Enemies
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().DoDamage(playerData.attackDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, playerData.attackRange);
    }
}
