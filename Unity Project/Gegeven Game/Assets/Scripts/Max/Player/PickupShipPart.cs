using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickupShipPart : MonoBehaviour
{
    [SerializeField]private int amountOfPartsPickedUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("shipPart"))
        {
            amountOfPartsPickedUp++;
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        RepairShip();
    }

    private void RepairShip()
    {
        if(amountOfPartsPickedUp >= 4)
        {
            //do a thing
        }
    }
}
