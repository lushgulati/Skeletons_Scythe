using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostNPC : MonoBehaviour
{
    public Animator ani;

    void OnTriggerEnter2D(Collider2D other)
    {
        ani.SetBool("ghostDisappear", false);
        ani.SetBool("ghostGone", false);
        ani.SetBool("ghostState", true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        ani.SetBool("ghostDisappear", true);
        ani.SetBool("ghostState", false);
        ani.SetBool("ghostGone", true);
    }
}
