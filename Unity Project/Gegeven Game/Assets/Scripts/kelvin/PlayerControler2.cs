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
    private SpriteRenderer spriteRen;

    public int jumpsvalue;
    private int jumps;

    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        rigiBody = GetComponent<Rigidbody2D>();
        jumps = jumpsvalue;
        spriteRen.flipX = false;
    }

    private void FixedUpdate()
    {
        xAxis = XCI.GetAxis(XboxAxis.LeftStickX);
        rigiBody.velocity = new Vector2(xAxis * moveSpeed, rigiBody.velocity.y);
       
    }
    private void Update()
    {
        if (XCI.GetButtonDown(XboxButton.A) && jumps > 0)
        {
            rigiBody.velocity = Vector2.up * force;
            jumps--;
        }
        if (xAxis < 0.1)
        {
            spriteRen.flipX = true;
        }
        if (xAxis > 0.1)
        {
            spriteRen.flipX = false;
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

