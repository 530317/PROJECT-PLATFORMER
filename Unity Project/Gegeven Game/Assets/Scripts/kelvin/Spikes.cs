using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.DOPunchPosition(new Vector3(1f, 0f), 1f);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //if (player.transform.position.x < transform.position.x - 0.01f)
        //{
        //    player.transform.DOMoveX(-18, 2.5f);
        //}
        //else
        //{
        //    player.transform.DOMoveX(transform.position.x, 2.5f);
        //}
    }
}
