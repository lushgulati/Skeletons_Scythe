using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int souls = 10;
    public Rigidbody2D EnemyRB;
    public Animator animator;
    public MonoBehaviour component;
    public SpriteRenderer spriterenderer;
    public GameObject attackpoint;
    public ParticleSystem bleed;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        
            bleed.Play();
        

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    

    void Die()
    {
        Debug.Log("Enemy died");
        animator.SetBool("dead", true);
        EnemyRB.gravityScale = 1;
        Freezer freezer = GetComponent<Freezer>();
        freezer.Freeze();
        component.enabled = false;
        gameObject.layer = 11;
        GetComponent<EnemyAttack>().enabled = false;
        spriterenderer.sortingLayerID = SortingLayer.NameToID("DeadEnemies");
        this.enabled = false;
        FindObjectOfType<SoulCounter>().CollectSouls(souls);
    }
}
