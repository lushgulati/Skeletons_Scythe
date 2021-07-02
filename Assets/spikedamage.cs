using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikedamage : MonoBehaviour
{
    public static Vector2 attackRange;
    public LayerMask player;
    public int attackDamage = 10;
    //public Transform AttackPoint;
    private bool hasCollide = false;
    public bool hasPlatform = false;
    public Platform platform;
    // Start is called before the first frame update
    void Start()
    {
        attackRange = new Vector2(4.2f, 1.8f);
        if(hasPlatform)
        {
            MoveWithPlatform();
        }

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        
    }
    public void Attack()
    {
        {
            Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, attackRange,0, player);
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
    private void OnDrawGizmosSelected()
    {
        
        Gizmos.DrawWireCube(transform.position, attackRange);
    }
    public void MoveWithPlatform()
    {
        this.transform.parent = platform.transform;
    }
}
