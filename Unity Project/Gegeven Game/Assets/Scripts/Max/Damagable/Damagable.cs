using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{

    public float health;

    public float enemyKnockedOutTime = 3f;
    private float bloodLossSpeed = 5f;

    private void Start()
    {
        health = Mathf.Clamp(100, 0, 100);
    }

    public void PlayerDamage(float damage)
    {
        health -= damage;
    }

    public void EnemyDamage(float damage)
    {
        health -= damage;

    }

    public IEnumerator BloodLossTime(float damageTime, int damageCount, float damageAmount)
    {
        int currentCount = 0;
        while(currentCount < damageAmount)
        {
            health -= damageAmount;
            yield return new WaitForSeconds(damageTime);
            currentCount++;
        }
    }

    public IEnumerator KnockOutTime()
    {
        yield return new WaitForSeconds(enemyKnockedOutTime);
    }

}
