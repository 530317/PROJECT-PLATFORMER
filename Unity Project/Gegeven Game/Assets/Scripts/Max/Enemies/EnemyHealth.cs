using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyHealth : Damagable
{
    public float throwBackForce;
    public float upThrowForce;

    private void Update()
    {
        WhenEnemyIsDown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fist"))
        {
            EnemyDamage(25);
            transform.DOShakeScale(1f, 0.1f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * upThrowForce, ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * throwBackForce, ForceMode2D.Impulse);
        }
    }

    private void WhenEnemyIsDown()
    {
        if(Health <= 0)
        {
            transform.DOScaleY(0, 1f);
        }
    }

    

}
