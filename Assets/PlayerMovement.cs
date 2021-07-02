using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public static bool canMove = true;
    public float DashForce;
    public float StartDashTimer;
    float CurrentDashTimer;
    float DashDirection;
    bool isDashing;
    public static Rigidbody2D m_Rigidbody2D;
    public float dashRate = 2f;
    float nextAttackTime = 0f;
    public bool canDash;
    public ParticleSystem dash;


    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if(Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                jump = true;
                
            }

            if(Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            } else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
            if (Time.time >= nextAttackTime)
            {
                if (canDash == true)
                {
                    if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalMove != 0)
                    {
                        Dash();
                        
                    }

                    if (isDashing)
                    {
                        //m_Rigidbody2D.velocity = transform.right * (DashDirection * DashForce);
                        animator.SetTrigger("Dash");
                        
                        m_Rigidbody2D.AddForce(transform.right * (DashDirection * DashForce));
                        m_Rigidbody2D.velocity = transform.up * 0;
                        CurrentDashTimer -= Time.deltaTime;
                        if (CurrentDashTimer <= 0)
                        {
                            isDashing = false;
                            nextAttackTime = Time.time + 1f / dashRate;
                        }
                    }


                }
            }
        }
    } 

    void Dash()
    {
        
            isDashing = true;
            CurrentDashTimer = StartDashTimer;
            m_Rigidbody2D.velocity = Vector2.zero;
            DashDirection = (int)horizontalMove;
        dash.Play();




    }

    public void OnLanding()
    { animator.SetBool("Jump", false); }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Platform"))
        {
            Debug.Log("Platform entered");
            this.transform.parent = col.transform;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Platform"))
        {
            this.transform.parent = null;
        }
    }
    

}
