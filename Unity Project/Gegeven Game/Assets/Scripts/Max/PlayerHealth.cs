using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Damagable
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PlantStem"))
        {
            PlayerDamage(50);
        }
    }
}
