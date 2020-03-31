using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using static Platformer.Mechanics.PatrolPath;
using DG.Tweening;

public class GroundEnemy : MonoBehaviour
{
    public GameObject beginposobject;
    public GameObject endposobject;

    public Vector3 beginpos;
    public Vector3 endpos;

    private SpriteRenderer spriteRen;

    private float smooth = 50f;
    private float step;
    private float Target;
    public float speed;

    bool movebegin;

    private void Start()
    {
        movebegin = true;
        spriteRen = GetComponent<SpriteRenderer>();
        beginpos = beginposobject.transform.position;
        endpos = endposobject.transform.position;
    }
    private void Update()
    {
            Move();
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
