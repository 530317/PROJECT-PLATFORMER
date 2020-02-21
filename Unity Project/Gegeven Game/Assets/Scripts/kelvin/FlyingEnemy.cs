﻿using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using static Platformer.Mechanics.PatrolPath;

public class FlyingEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject beginposobject;
    public GameObject endposobject;
    public Vector3 beginpos;
    public Vector3 endpos;
    public float speed;
    bool movebegin;
    private SpriteRenderer spriteRen;
    private float smooth = 50f;
    private float step;
    private float Target;
    private bool atack;

    private void Start()
    {
        movebegin = true;
        spriteRen = GetComponent<SpriteRenderer>();
        beginpos = beginposobject.transform.position;
        endpos = endposobject.transform.position;
    }
    private void Update()
    {
        
        if (atack)
        {
            Atack();
        }
        else
            Move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            atack = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        atack = false;
    }
    private void Atack()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    private void Move()
    {
        step = speed * Time.deltaTime;
        if (movebegin)
        {
            transform.position = Vector3.MoveTowards(transform.position, beginpos, step);
            spriteRen.flipX = false;
        }
        if (transform.position == beginpos)
        {
            movebegin = false;
        }
        if (movebegin == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, endpos, step);
            spriteRen.flipX = true;
        }
        if (transform.position == endpos)
        {
            movebegin = true;
        }
    }

}
