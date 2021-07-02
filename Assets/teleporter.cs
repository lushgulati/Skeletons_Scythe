using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public Boss body;
    public EnemyDamage enemy;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Boss>();
        enemy = GetComponent<EnemyDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.currentHealth<=1500)
        {
            Debug.Log("teleport");
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
        }
    }
}
