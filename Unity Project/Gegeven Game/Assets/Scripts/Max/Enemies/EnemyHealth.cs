using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using XboxCtrlrInput;

public class EnemyHealth : Damagable
{
    public float throwBackForce;
    public float upThrowForce;

    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        WhenEnemyIsDown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fist"))
        {
            audioSource.Play();
            EnemyDamage(35);
            transform.DOPunchScale(new Vector2(0.05f, 0.05f), 1f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * upThrowForce, ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * throwBackForce, ForceMode2D.Impulse);
        }
    }

    private void WhenEnemyIsDown()
    {
        if(health <= 0)
        {
            transform.DOScaleY(0, 1f);
        }
    }

    

}
