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

    [SerializeField] private Color color = Color.white;
    [SerializeField] private Color color2 = Color.white;

    private void Update()
    {
        WhenEnemyIsDown();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("fist"))
        {
            audioSource.Play();
            EnemyDamage(15);
            StartCoroutine(EnemyFlash(0.1f));
            //transform.DOPunchScale(new Vector2(0.05f, 0.05f), 1f);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * upThrowForce, ForceMode2D.Impulse);
            gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * throwBackForce, ForceMode2D.Impulse);
        }
    }

    private void WhenEnemyIsDown()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator EnemyFlash(float cooldown)
    {
        for (int i = 0; i < 1; i++)
        {
            gameObject.GetComponent<SpriteRenderer>().color = color;

            yield return new WaitForSeconds(cooldown);

            gameObject.GetComponent<SpriteRenderer>().color = color2;

            yield return new WaitForSeconds(cooldown);
        }
    }
}
