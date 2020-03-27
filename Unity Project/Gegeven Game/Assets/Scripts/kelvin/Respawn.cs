using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject respan;
    public GameObject playerprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Spawnplayer();
        }
    }
    void Spawnplayer()
    {

        Instantiate(playerprefab, respan.transform.position, Quaternion.identity);
        playerprefab = player;
    }
}
