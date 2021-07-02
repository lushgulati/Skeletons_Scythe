using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingPlatform : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D bc;
    private bool check;
    public ParticleSystem Dust;
    private Vector3 temp;
    bool particleSystemPlayed = false;
    public GameObject prefab;
    bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyed = false;
        check = false;
        body = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        bc.enabled = true;
        body.isKinematic = true;
        temp = gameObject.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (check == true)
        {
            if (!particleSystemPlayed)
            {
                
                Dust.Play();
                particleSystemPlayed = true;
            }

            StartCoroutine(Crumbling(1,7));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        check = true;
    }
    IEnumerator Crumbling(float delay, float back)
    {
        
        yield return new WaitForSeconds(delay);
        body.isKinematic = false;
        bc.enabled = false;
        yield return new WaitForSeconds(back);
        
        if (!destroyed)
        {
            Instantiate(prefab, temp, Quaternion.identity);
            destroyed = true;
            this.enabled = false;
            
        }



    }
}
