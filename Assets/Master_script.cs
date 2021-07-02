using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master_script : MonoBehaviour
{
    public int maxHealth = 150;
    public int currentHealth;
    public static bool l_spike_active;
    public GameObject l_spikes;
    public GameObject r_spikes;
    public GameObject[] objectPool;
    private int currentIndex = 0;
    public static bool arrow_active;
    public GameObject platforms;
    public GameObject health;
    public EnemyDamage enemy;
    [SerializeField]
    public GameObject fireball;
    private GameObject instantiatedObj;
    public static bool fireball_active;
    public GameObject laser;
    public static bool laser_active;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        CinemachineShake.Instance.ShakeCamera(5f, 5f);
        StartCoroutine(OnStart());
    }


    // Update is called once per frame
    void Update()
    {
        if (enemy.currentHealth > 1500) { 
        Spikes();
        ArrowRandom();
               
        }
        if(enemy.currentHealth<=1500&&enemy.currentHealth>0)
        {
            StartCoroutine(SecondPhase());
        }
        if(enemy.currentHealth<=0)
        {
            Die();
        }
        
    }

    void Spikes()
    {
        
        
            if (l_spike_active == true)
            {
            StartCoroutine(SpikeSwitcher1());
            }
            else
            {
            StartCoroutine(SpikeSwitcher2());
            }


        

    }
    public void ArrowRandom()
    {
        if (arrow_active == true)
        {
            StartCoroutine(ArrowSwitcher());
        }
    }
    public void Fireball()
    {

        if (fireball_active == true)
        {
            StartCoroutine(Fireball_activate());
        }
        
    }
    public void Laser()
    {
        if(laser_active==true)
        {
            StartCoroutine(LaserActivate());
        }
    }
    public void Die()
    {
        r_spikes.SetActive(false);
        l_spikes.SetActive(false);
        laser_active = false;
        fireball_active = false;
        
       
    }

    IEnumerator Fireball_activate()
    {

        var position = new Vector3(Random.Range(-78, -44), 25, 0);
        instantiatedObj = (GameObject)Instantiate(fireball, position, Quaternion.identity);
        CinemachineShake.Instance.ShakeCamera(2f, .5f);
        fireball_active = false;
        yield return new WaitForSeconds(0.5f);
        Destroy(instantiatedObj, 8);
        fireball_active = true;
    }

    IEnumerator SpikeSwitcher1()
    {
        r_spikes.SetActive(true);
        yield  return new WaitForSeconds(7);
        r_spikes.SetActive(false);
        l_spike_active = false;
    }
    IEnumerator SpikeSwitcher2()
    {
        l_spikes.SetActive(true);
        yield return new WaitForSeconds(7);
        l_spikes.SetActive(false);
        l_spike_active = true;
    }
    IEnumerator LaserActivate()
    {
        laser.SetActive(true);
        laser_active = false;
        yield return new WaitForSeconds(5);
        laser.SetActive(false);
        yield return new WaitForSeconds(Random.Range(2,6));
        laser_active = true;
    }
    IEnumerator ArrowSwitcher()
    {
        //yield return new WaitForSeconds(3);
        int newIndex = Random.Range(0, 3);
        
        currentIndex = newIndex;
        //currentIndex = Random.Range(0, 3);
        objectPool[currentIndex].SetActive(true);
        Debug.Log(currentIndex);
        arrow_active = false;
        yield return new WaitForSeconds(9);
        objectPool[currentIndex].SetActive(false);
        arrow_active = true;
    }
    IEnumerator OnStart()
    {
        
        yield return new WaitForSeconds(3);
        l_spike_active = true;
        arrow_active = true;
        health = GameObject.Find("Boss_body");
        enemy = health.GetComponent<EnemyDamage>();

        fireball_active = true;
        laser_active = true;
    }
    IEnumerator SecondPhase()
    {

        platforms.SetActive(true);
        
        yield return new WaitForSeconds(6);
            arrow_active = false;
            ArrowRandom();
            r_spikes.SetActive(true);
            l_spikes.SetActive(true);

            Fireball();
            Laser();
            
    }
    
    
}
