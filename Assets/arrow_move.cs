using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_move : MonoBehaviour
{

    [SerializeField]
    float Linear_speed;
    Vector2 pos;
    void Start()
    {
        pos = new Vector2(-50f,-9.8f);
        
        gameObject.transform.position = pos;

    }
    void OnEnable()
    {
        gameObject.transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= -transform.right * Linear_speed * Time.deltaTime;
    }
}
