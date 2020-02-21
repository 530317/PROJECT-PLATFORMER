using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBootToSelector : MonoBehaviour
{
    public GameObject player;

    public int bootId;

    private ItemSelector itemSelector;
    private void Start()
    {
        itemSelector = FindObjectOfType<ItemSelector>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            itemSelector.boots[bootId] = gameObject;
            gameObject.SetActive(false);
            transform.position = player.transform.position;
            transform.parent = player.transform;
        }
    }
}
