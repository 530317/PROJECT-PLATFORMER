using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Damagable
{
    public float oxygenLvl;

    public Slider oxygenSlider;
    public Slider healthSlider;

    private void Update()
    {
        if (oxygenLvl <= 0)
        {
            StartCoroutine(BloodLossTime(1000, 1, 0.1f));
        }
        else if (oxygenLvl > 0)
        {
            StopAllCoroutines();
        }

        oxygenSlider.value = oxygenLvl;
        healthSlider.value = health;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlantStem"))
        {
            if (oxygenLvl <= 0)
            {
                Oxygen(0);
            }
            else
            {
                Oxygen(20);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("oxygenTank"))
        {
            AddOxygen(25f);
        }
    }

    private void Oxygen(float oxygenDamage)
    {
        oxygenLvl -= oxygenDamage;
    }

    private void AddOxygen(float amountOfOxygen)
    {
        oxygenLvl += amountOfOxygen;
    }
}
