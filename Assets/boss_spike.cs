using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_spike : MonoBehaviour
{
    public static Vector2 attackRange;
    public LayerMask player;
    public int attackDamage = 10;
    //public Transform AttackPoint;
    private bool hasCollide = false;
    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        attackRange = new Vector2(9.1f, 1.6f);
        


    }
    void OnEnable()
    {
        attackRange = new Vector2(9.1f, 1.6f);



    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Buildup());
        

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
    IEnumerator GiveDamage()
    {

        yield return new WaitForSeconds(1);
        hasCollide = false;
    }
    IEnumerator Buildup()
    {
        yield return new WaitForSeconds(2);
        animator.SetBool("spike damage", true);
        Attack();

    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.DrawWireCube(transform.position, attackRange);
    }

}
