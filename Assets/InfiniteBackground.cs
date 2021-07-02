using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{
    private float length, startpos;
    public Transform cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cam.position.x * (1 - parallaxEffect));
        float dist = (cam.position.x * parallaxEffect);


        transform.position = new Vector3(startpos + dist, cam.position.y * parallaxEffect, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
        
    }
}
