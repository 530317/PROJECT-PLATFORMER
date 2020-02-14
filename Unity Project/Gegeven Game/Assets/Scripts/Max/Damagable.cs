using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int Health;

    public int enemyHealth; 
    public float enemyKnockedOutTime = 3f;

    public void PlayerDamage(int damage)
    {
        Health -= damage;

    }

    public void EnemyDamage(int damage)
    {
        Health -= damage;

    }

    public IEnumerator KnockOutTime()
    {
        yield return new WaitForSeconds(enemyKnockedOutTime);
    }

}
