using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class SoulCounter : MonoBehaviour
{
    public Text counter;
    public HealthBar healthBar;
    public Animator animator;
    public ParticleSystem heal;

    void Start()
    {
        counter.text = "0";
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            bool max = healthBar.checkIfMax();
            if(int.Parse(counter.text) > 0 && max)
            {
                animator.SetTrigger("heal");
                heal.Play();
                StartCoroutine(UseSouls());
                
                    //Player Movement disabled for 2 seconds 
                int totalSouls = int.Parse(counter.text) - 10;
                counter.text = totalSouls.ToString();
                healthBar.increaseHealth();
                
            }
            
        }
    }
    
    public void CollectSouls(int souls)
    {
        int totalSouls = int.Parse(counter.text) + souls;
        counter.text = totalSouls.ToString();
    }

    public void merchantSouls()
    {
        int totalSouls = int.Parse(counter.text) + 200;
        counter.text = totalSouls.ToString();
    }
    IEnumerator UseSouls()
    {
        PlayerMovement.canMove = false;
        FindObjectOfType<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(1);
        FindObjectOfType<PlayerMovement>().enabled = true;
        PlayerMovement.canMove = true;
    }
}
