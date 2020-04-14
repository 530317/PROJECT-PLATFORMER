using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndAnimation : MonoBehaviour
{
    [SerializeField] private GameObject parts1;
    [SerializeField] private GameObject parts2;
    [SerializeField] private GameObject parts3;
    [SerializeField] private bool endScene;

    private GameObject ship; 
    public GameObject shipLocation;
    public GameObject shipLocation2;
   
    private float step;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        step = speed * Time.deltaTime;
        if (endScene)
        {
            //Instantiate(ship, new Vector3(shipLocation.transform.position.x, shipLocation.transform.position.y, shipLocation.transform.position.z), Quaternion.identity);
            ship.transform.position = Vector3.MoveTowards(shipLocation.transform.position, shipLocation2.transform.position, step);
        }
    }
}
