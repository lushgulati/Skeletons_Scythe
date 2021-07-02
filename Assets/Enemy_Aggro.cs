using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Aggro : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float AggroDistance;

    [SerializeField]
    float moveSpeed;

    Animator ani;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer < AggroDistance)
        {
            chasePlayer();
        }
        else
        {
            stopChasing();
        }
    }

    void chasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(transform.position.x - player.position.x < 0.1)
        {
            rb2d.velocity = new Vector2(0, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        ani.Play("moving_mimic");
    }

    void stopChasing()
    {
        rb2d.velocity = new Vector2(0, 0);
        ani.Play("idle_mimic");
    }
}
