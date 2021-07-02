using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_movement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startingPosition;
    [SerializeField]
    float maxDistanceFromStart;

    [SerializeField]
    float freq;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startingPosition + Vector3.up * Mathf.Sin(Time.realtimeSinceStartup * freq) * maxDistanceFromStart;
    }
}
