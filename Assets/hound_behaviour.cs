using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hound_behaviour : MonoBehaviour
{
    bool moving_right = false;
    
    public Transform groundDetection;

    public Transform playerDetection;

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

        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundinfo.collider == false)
        {
            if (moving_right == true)
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

        RaycastHit2D hit;

        if (moving_right == true)
        {
            hit = Physics2D.Raycast(playerDetection.position, Vector2.left, 5f);
        }
        else
        {
            hit = Physics2D.Raycast(playerDetection.position, Vector2.right, 5f);
        }

        if (hit.collider.gameObject.tag == "Player")
        { 
            Linear_speed = 6f;
            ani.Play("blood_run");
        }
        else
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }
}
