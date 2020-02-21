using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damagable
{
    public int oxygenLvl;

    private void Update()
    {
        if (oxygenLvl <= 0)
        {
            PlayerDamage(25);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlantStem"))
        {
            Oxygen(20);
        }
    }

    private void Oxygen(int oxygenDamage)
    {
        oxygenLvl -= oxygenDamage;
    }

}
