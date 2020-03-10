using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
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
        //GamePad.SetVibration(0, 20, 20);
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
