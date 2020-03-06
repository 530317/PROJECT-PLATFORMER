using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveOxygen : PlayerHealth
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            AddOxygen(25f);
            Destroy(gameObject);
        }
    }
}
