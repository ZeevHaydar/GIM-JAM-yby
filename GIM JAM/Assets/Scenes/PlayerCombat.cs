using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 1.0f;
    public LayerMask enemyLayers;
    public float attackSpeed = 0.5f;
    float attackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= attackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                MeleeAttack();
                attackTime = Time.time + attackSpeed;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                RangeAttack();
            }
        }

    }

    void MeleeAttack()
    {
        // attack animation

        // detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // hit the enemy if detected
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Lu nggitik " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }
    }
    void RangeAttack()
    {

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
