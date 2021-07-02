using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_behaviour : MonoBehaviour
{
    bool moving_right = false;
    public Transform groundDetection;

    [SerializeField]
    Transform player;

    [SerializeField]
    float freq;

    [SerializeField]
    float sine_amplitude;

    [SerializeField]
    float offset;

    [SerializeField]
    float Linear_speed;

    Animator ani;
    Vector3 pos;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        ani = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pos -= transform.right * Time.deltaTime * Linear_speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * freq) * sine_amplitude;

        float distToPlayer = Vector2.Distance(transform.position, player.position);

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundinfo.collider == false)
        {
            if(moving_right == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moving_right = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moving_right = true;
            }


        }

        if (distToPlayer < 4)
        {
            ani.Play("ghost_chase");
        }
        else
        {
            ani.Play("ghost_idle");
        }   
    }
}