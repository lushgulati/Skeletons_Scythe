using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Animator animator;
    public Dialogue dialogue;
    public static bool check = false;

    void Update()
    {
        if(check)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("IsTriggered", false);
                TriggerDialogue();
                check = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("IsTriggered", true);
        check = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        animator.SetBool("IsTriggered", false);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    
}
