using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilwiz_run : StateMachineBehaviour
{
    
    public float speed = 3.7f;
    public float attack_range = 3f;

    Transform player;
    Rigidbody2D rb2d;
    flipsprite fs;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        fs = animator.GetComponent<flipsprite>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fs.LookAtPlayer();

        float disttoplayer = Vector2.Distance(rb2d.position, player.position);
        
        Vector2 target = new Vector2(player.position.x, rb2d.position.y);
        Vector2 newpos = Vector2.MoveTowards(rb2d.position, target, speed * Time.fixedDeltaTime);
        
        if (disttoplayer < 8f)
        {
            rb2d.MovePosition(newpos);
        }

        if(disttoplayer < attack_range)
        {
            animator.SetTrigger("attack");
        }
    }

     //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

}
