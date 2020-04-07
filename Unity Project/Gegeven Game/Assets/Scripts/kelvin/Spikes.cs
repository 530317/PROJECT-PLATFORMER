using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject player;
    public float force = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           player.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,force), ForceMode2D.Impulse);
            print("up");
            print(collision.gameObject);
        }
    }
}
