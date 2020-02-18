using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;


public class PlayerControler2 : MonoBehaviour
{
    public float moveSpeed;
    public float force;
    private float xAxis;

    private Rigidbody2D rigiBody;

    public int jumpsvalue;
    private int jumps;

    private void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        jumps = jumpsvalue;
    }

    private void FixedUpdate()
    {
        xAxis = XCI.GetAxis(XboxAxis.LeftStickX);
        rigiBody.velocity = new Vector2(xAxis * moveSpeed, rigiBody.velocity.y);
    }
    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.A)&& jumps > 0)
        {
            rigiBody.velocity = Vector2.up * force;
            jumps--;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         print("hit");
        if (collision.gameObject.tag == "Ground")
        {
            print("ground");
            jumps = jumpsvalue;
        }
    }

}

