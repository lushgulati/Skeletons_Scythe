using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallspikedamage : MonoBehaviour
{
    public static Vector2 attackRange;
    public LayerMask player;
    public int attackDamage = 10;
    //public Transform AttackPoint;
    private bool hasCollide = false;
    // Start is called before the first frame update
    void Start()
    {
        attackRange = new Vector2(1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        Attack();

    }
    public void Attack()
    {
        {
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, attackRange, 0, player);
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
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireCube(transform.position, attackRange);
    }
    IEnumerator GiveDamage()
    {

        yield return new WaitForSeconds(1);
        hasCollide = false;
    }
}
