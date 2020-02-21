using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlantAttack : MonoBehaviour
{
    PlantBehaviour plantBehaviour;
    public GameObject parentObj;
    public GameObject player;

    private Vector3 starPos;

    void Start()
    {
        starPos = transform.position;
        plantBehaviour = FindObjectOfType<PlantBehaviour>();
    }

    void Update()
    {
        if(plantBehaviour.playerInSight == true)
        {
            transform.DOMove(player.transform.position, 0.5f).SetEase(Ease.OutElastic);
            player.GetComponent<Rigidbody2D>().AddForce(-transform.right, ForceMode2D.Force);
        }
        else if(plantBehaviour.playerInSight == false)
        {
            transform.position = starPos;
        }
    }
}
