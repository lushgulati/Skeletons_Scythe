using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_npc : MonoBehaviour
{

    [SerializeField]
    float visibleDistance;

    [SerializeField]
    Transform player;

    SpriteRenderer sprite;
    Animator ani;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer > visibleDistance)
        {
            sprite.color = new Color(1f, 1f, 1f, 0f);
        }
        else
        {
            ani.Play("ghost_visible");
            sprite.color = new Color(1f, 1f, 1f, 1f);
            ani.Play("ghost_npc");
        }
    }
}