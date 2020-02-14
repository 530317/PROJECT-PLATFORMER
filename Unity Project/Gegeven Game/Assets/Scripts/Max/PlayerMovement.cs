using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float xAxis;
    public float yAxis;
    public float speedPerTile;

    Vector3 speed;

    private void Start()
    {
        speed = new Vector3();
    }

    private void FixedUpdate()
    {
        GetAxis();

        speed = new Vector3(xAxis * speedPerTile, yAxis * speedPerTile);

        transform.position += speed * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speedPerTile = 10f;
        }
        else
        {
            speedPerTile = 7f;
        }

    }

    private void GetAxis()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
    }


    private void TextBoxDissapear()
    {
        StartCoroutine(DissapearTime());
    }

    private IEnumerator DissapearTime()
    {
        yield return new WaitForSeconds(3f);
    }

}
