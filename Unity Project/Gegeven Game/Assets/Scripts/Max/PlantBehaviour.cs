using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : Damagable
{
    public bool playerInSight = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("hit");
            playerInSight = true;
        }
        else if(!collision.CompareTag("Player"))
        {
            playerInSight = false;
        }
    }
}
