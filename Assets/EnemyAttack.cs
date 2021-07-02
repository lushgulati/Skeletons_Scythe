using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float attackRange = 0.5f;
    public LayerMask player;
    public int attackDamage = 50;
    public Transform AttackPoint;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    private bool hasCollide = false;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
                Attack();
                //nextAttackTime = Time.time + 1f / attackRate;
       }
        
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, player);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (hasCollide == false)
            {
                hasCollide = true;
                Debug.Log("hit" + enemy.name);
                PlayerCombat enemyDamage = enemy.GetComponent<PlayerCombat>();

                enemyDamage.TakeDmg(attackDamage);
                StartCoroutine(GiveDamage());
            }

        }
    }

    
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }
    IEnumerator GiveDamage()
    {
        
        yield return new WaitForSeconds(1);
        hasCollide = false;
    }
}
