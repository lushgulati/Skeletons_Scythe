using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    [SerializeField]
    float Linear_speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Linear_speed * Time.deltaTime;
        
    }
    
}
