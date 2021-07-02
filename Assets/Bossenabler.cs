using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossenabler : MonoBehaviour
{
    public GameObject Boss;
    public GameObject BossStand;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        BossStand.SetActive(false);
        Boss.SetActive(true);
        Destroy(gameObject);
    }
}
