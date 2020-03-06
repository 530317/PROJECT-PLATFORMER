﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;

public class PlayerHealth : Damagable
{
    public float oxygenLvl;

    public Slider oxygenSlider;
    public Slider healthSlider;

    private void Update()
    {
        StartCoroutine(OxygenTime(1000, 1, 0.08f));

        if (oxygenLvl <= 0)
        {
            StartCoroutine(BloodLossTime(1000, 1, 0.08f));

        }
        else if (oxygenLvl > 0)
        {
            StopAllCoroutines();
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        oxygenSlider.value = oxygenLvl;
        healthSlider.value = health;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlantStem"))
        {
            if (health <= 0)
            {
                PlayerDamage(15);
            }
            else
            {
                PlayerDamage(15);
            }
        }
    }

    public IEnumerator OxygenTime(float oxygenTime, int oxygenDamageCount, float oxygenDamageAmount)
    {
        int currentCount = 0;
        while (currentCount < oxygenDamageAmount)
        {
            oxygenLvl -= oxygenDamageAmount;
            yield return new WaitForSeconds(oxygenTime);
            currentCount++;
        }
    }

    private void Oxygen(float oxygenDamage)
    {
        oxygenLvl -= oxygenDamage;
    }

    public void AddOxygen(float amountOfOxygen)
    {
        oxygenLvl += amountOfOxygen;
    }
}
