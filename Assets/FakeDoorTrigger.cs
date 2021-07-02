using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoorTrigger : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("isFakeDoorTriggered", true);
    }
}
