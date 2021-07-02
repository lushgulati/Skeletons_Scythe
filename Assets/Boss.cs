using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
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

    public Animator ani;
    Vector3 pos;
    public bool canMove;
    public EnemyDamage enemy;
    public bool teleported;
    public GameObject light;
    public ParticleSystem teleport;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        canMove = false;
        StartCoroutine(StartMove());
        enemy = GetComponent<EnemyDamage>();
        teleported = false;
    }
    void OnEnable()
    {
        pos = transform.position;
        canMove = false;
        StartCoroutine(StartMove());

    }

    // Update is called once per frame
    void Update()
    {
        
        if (canMove == true)
        {
            if (enemy.currentHealth <= 1500&&enemy.currentHealth>0)
            {
                StartCoroutine(Teleport());
            }
            if(enemy.currentHealth>1500)
            {
                Move();
            }
            if(enemy.currentHealth<=0)
            {
                StartCoroutine(Die());
            }
        }

      
    }
    void Move()
    {
        pos -= transform.right * Time.deltaTime * Linear_speed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * freq) * sine_amplitude;



        RaycastHit2D groundinfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);

        if (groundinfo.collider == true)
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
    }
    IEnumerator Die()
    {
        ani.SetTrigger("teleport");
        light.SetActive(true);
        teleport.Play();
        CinemachineShake.Instance.ShakeCamera(5f, 4f);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    IEnumerator StartMove()
    {
        
        yield return new WaitForSeconds(3);
        ani.SetTrigger("entry");
        canMove = true;
    }
    IEnumerator Teleport()
    {
        if (teleported == false)
        {
            ani.SetTrigger("teleport");
            light.SetActive(true);
            teleport.Play();
            CinemachineShake.Instance.ShakeCamera(5f, 5f);
            yield return new WaitForSeconds(3);
            
            pos = new Vector3(-61.7f, 5.5f, 0f);
            teleported = true;
            light.SetActive(false);
        }
        Move();
    }
}
