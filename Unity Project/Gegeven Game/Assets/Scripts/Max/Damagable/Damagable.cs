using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{

    public int Health;

    public float enemyKnockedOutTime = 3f;
    private float bloodLossSpeed = 5f;

    public void PlayerDamage(int damage)
    {
        StartCoroutine(BloodLossTime());
        Health -= damage;
    }

    public void EnemyDamage(int damage)
    {
        Health -= damage;

    }

    public IEnumerator BloodLossTime()
    {
        yield return new WaitForSeconds(bloodLossSpeed);
    }

    public IEnumerator KnockOutTime()
    {
        yield return new WaitForSeconds(enemyKnockedOutTime);
    }

}
