using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    void Update()
    {
        if(slider.value <= 0)
        {
            FindObjectOfType<gameOver>().gameIsOver();
        }
    }
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
    public void increaseHealth()
    {
        slider.value += 10;
        FindObjectOfType<PlayerCombat>().UpdateHealth();
    }
    public bool checkIfMax()
    {
        if (slider.value == slider.maxValue)
            return false;
        else
            return true;
    }
    public void merchantUpdate()
    {
        slider.value = slider.maxValue;
    }
}
