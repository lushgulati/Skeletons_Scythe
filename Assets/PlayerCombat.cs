using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public HealthBar healthBar;

    public Transform AttackPoint;
    public float attackRange = 0.5f;
    public Transform DownAttackPoint;
    public float downattackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask spikeLayers;
    public ParticleSystem slash;
    public ParticleSystem cut;
    public ParticleSystem hurt;
    public ParticleSystem downslash;
    public ParticleSystem downcut;
    public int attackDamage = 50;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int maxHealth = 150;
    public int currentHealth;
    private Rigidbody2D rb;
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButton("Down") && PlayerMovement.canMove == true && CharacterController2D.m_Grounded==false)
            {
                if (Input.GetButtonDown("Attack"))
                {

                    DownAttack();
                    Debug.Log("Downatk");
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
            else if (Input.GetButtonDown("Attack") && PlayerMovement.canMove == true)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            
            
        }
    }
    

    void Attack()
    {
        animator.SetTrigger("Attack");
        slash.Play();
        Collider2D[] hitEnemies=Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit" + enemy.name);
            EnemyDamage enemyDamage = enemy.GetComponent<EnemyDamage>();
            enemyDamage.TakeDamage(attackDamage);
            cut.Play();
            if (GetComponent<CharacterController2D>().m_FacingRight == true&& enemyDamage.currentHealth > 0)
            {
                enemyDamage.GetComponent<Rigidbody2D>().AddForce(  transform.right * 4000);
                GetComponent<Rigidbody2D>().AddForce( transform.right * -1500);
            }
            else if (GetComponent<CharacterController2D>().m_FacingRight == false && enemyDamage.currentHealth > 0)
            {
                enemyDamage.GetComponent<Rigidbody2D>().AddForce( (transform.right * 4000) * -1);
                GetComponent<Rigidbody2D>().AddForce(transform.right * 1500);
            }
        }
    }

    void DownAttack()
    {
        animator.SetTrigger("DownAttack");
        downslash.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(DownAttackPoint.position, downattackRange, enemyLayers);
        Collider2D[] hitSpikes = Physics2D.OverlapCircleAll(DownAttackPoint.position, downattackRange, spikeLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("hit" + enemy.name);
            EnemyDamage enemyDamage = enemy.GetComponent<EnemyDamage>();
            enemyDamage.TakeDamage(attackDamage);
            downcut.Play();
            if ( enemyDamage.currentHealth>0)
            {
                enemyDamage.GetComponent<Rigidbody2D>().AddForce(transform.up * -2000);
                GetComponent<Rigidbody2D>().AddForce(transform.up * 1000);
            }
            
        }
        
            foreach (Collider2D spike in hitSpikes)
            {
                downcut.Play();
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1500f));
            break;
            

            }
        
    }

    public void TakeDmg(int damage)
    {
        animator.SetTrigger("hurt");
        hurt.Play();
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(DamageEffectSequence(sr, Color.grey, 2, 0));
        
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        Freezer freezer = GetComponent<Freezer>();
        freezer.Freeze();
        if (GetComponent<CharacterController2D>().m_FacingRight == true)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 400 + transform.right * -4000 );
        }
        else if (GetComponent<CharacterController2D>().m_FacingRight == false)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * 400 + transform.right * 4000);
        }

    }
    
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        if (DownAttackPoint == null)
            return;
        Gizmos.DrawWireSphere(DownAttackPoint.position, downattackRange);
    }
    IEnumerator DamageEffectSequence(SpriteRenderer sr, Color dmgColor, float duration, float delay)
    {
        // save origin color
        Color originColor = sr.color;

        // tint the sprite with damage color
        sr.color = dmgColor;
        

        // you can delay the animation
        yield return new WaitForSeconds(delay);

        // lerp animation with given duration in seconds
        for (float t = 0; t < 1.0f; t += Time.deltaTime / duration)
        {
            sr.color = dmgColor;
            gameObject.layer = 1;

            yield return null;
        }
        gameObject.layer = 8;
        // restore origin color
        sr.color = Color.white;
    }
    public void UpdateHealth()
    {
        currentHealth += 10;
    }
    public void metMerchant()
    {
        currentHealth = maxHealth;
    }
}
