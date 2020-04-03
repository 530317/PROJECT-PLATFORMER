using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public enum PlayerState
{
    idle = 0,
    moving = 1,
    punch = 2
}

public enum PlayerDirection
{
    idle,
    right,
    left,
    up,
    punch
}

public class PlayerControler2 : MonoBehaviour
{
    public float moveSpeed;
    public float force;
    private float xAxis;

    private Rigidbody2D rigiBody;
    private SpriteRenderer spriteRen;

    public int jumpsvalue;
    private int jumps;

    public Animator playerAnimator;
    public PlayerState playerState;
    public PlayerDirection playerDirection;

    private void Start()
    {
        spriteRen = GetComponent<SpriteRenderer>();
        rigiBody = GetComponent<Rigidbody2D>();
        jumpsvalue = 1;
        jumps = jumpsvalue;
    }

    private void FixedUpdate()
    {
        xAxis = XCI.GetAxis(XboxAxis.LeftStickX);
        rigiBody.velocity = new Vector2(xAxis * moveSpeed, rigiBody.velocity.y);
       
    }
    private void Update()
    {
        UpdateAnimatorValues();

        if (XCI.GetButtonDown(XboxButton.A) && jumps > 0)
        {
            rigiBody.velocity = Vector2.up * force;
            jumps--;
        }
        if (xAxis > 0.1)
        {
            playerState = PlayerState.moving;
            playerDirection = PlayerDirection.right;
        }
        if (xAxis < 0.1)
        {
            playerState = PlayerState.moving;
            playerDirection = PlayerDirection.left;
        }
        if(xAxis == 0)
        {
            playerDirection = PlayerDirection.idle;
        }
        if (xAxis == 0.1)
        {
            print("still");
        }
        if (XCI.GetButton(XboxButton.X))
        {
            playerDirection = PlayerDirection.punch;
        }


        PlayerFace();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         print("hit");
        if (collision.gameObject.tag == "Ground")
        {
            print("ground");
            jumps = jumpsvalue;
        }
        if (collision.gameObject.tag == "jump boost")
        {
            print("boost");
            jumpsvalue = 2;
        }
    }

    private void UpdateAnimatorValues()
    {
        playerAnimator.SetInteger("state", (int)playerState);
        playerAnimator.SetFloat("direction", (float)playerDirection);
    }

    private void PlayerFace()
    {
        if (playerDirection == PlayerDirection.right)
        {
            spriteRen.flipX = true;
        }
        if (playerDirection == PlayerDirection.left)
        {
            spriteRen.flipX = false;
        }
        if (playerDirection == PlayerDirection.idle && playerDirection == PlayerDirection.right)
        {
            spriteRen.flipX = true;
        }
        if (playerDirection == PlayerDirection.idle && playerDirection == PlayerDirection.left)
        {
            spriteRen.flipX = false;
        }
    }
}

