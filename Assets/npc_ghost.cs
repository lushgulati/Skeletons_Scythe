using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_ghost : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered collider");
        animator.SetBool("isGhostAppeared", true);
    }
}