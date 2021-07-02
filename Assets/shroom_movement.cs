using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shroom_movement : MonoBehaviour
{

    [SerializeField]
    float moveDist;

    [SerializeField]
    float move_speed;

    Vector2 initialPosition;
    int direction;
    float rightlim;
    float leftlim;

    Animator ani;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        direction = -1;
        rightlim = transform.position.x + moveDist;
        leftlim = transform.position.x - moveDist;
    }

    // Update is called once per frame
    void Update()
    {
        switch (direction)
        {
            case -1:
                // Moving Left
                if (transform.position.x > leftlim)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-move_speed, GetComponent<Rigidbody2D>().velocity.y);
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    direction = 1;
                }
                break;
            case 1:
                //Moving Right
                if (transform.position.x < rightlim)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(move_speed, GetComponent<Rigidbody2D>().velocity.y);
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    direction = -1;
                }
                break;
        }
    }

}