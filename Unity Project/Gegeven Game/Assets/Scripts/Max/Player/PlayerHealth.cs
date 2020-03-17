using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;
using DG.Tweening;

public class PlayerHealth : Damagable
{
    public float oxygenLvl;

    public float damageCooldown;

    public Slider oxygenSlider;
    public Slider healthSlider;

    [SerializeField]private bool isTakingDamage = false;

    PauseMenu pauseMenu;

    [SerializeField] private AudioSource audio;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }
    private void Update()
    {
        StartCoroutine(OxygenTime(1000, 1, 0.08f));

        if(isTakingDamage)
        {
            StartCoroutine(DamageCooldown(damageCooldown));
        }

        if (oxygenLvl <= 0)
        {
            StartCoroutine(BloodLossTime(1000, 1, 0.08f));

        }
        else if (oxygenLvl > 0)
        {
            StopAllCoroutines();
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        oxygenSlider.value = oxygenLvl;
        healthSlider.value = health;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlantStem"))
        {
            audio.Play();
            if (health > 0)
            {
                if(damageCooldown == 0)
                {
                    PlayerDamage(3f);
                    isTakingDamage = true;
                }
            }
            else
            {
                isTakingDamage = false;
            }
        }

        if (collision.CompareTag("oxygenTank"))
        {
            AddOxygen(25f);
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator OxygenTime(float oxygenTime, int oxygenDamageCount, float oxygenDamageAmount)
    {
        int currentCount = 0;
        while (currentCount < oxygenDamageAmount)
        {
            oxygenLvl -= oxygenDamageAmount;
            yield return new WaitForSeconds(oxygenTime);
            currentCount++;
        }

        if (pauseMenu.paused == true)
        {
            StopCoroutine("OxygenTime");
        }

    }

    private IEnumerator DamageCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
    }

    private void Oxygen(float oxygenDamage)
    {
        oxygenLvl -= oxygenDamage;
    }

    public void AddOxygen(float amountOfOxygen)
    {
        oxygenLvl += amountOfOxygen;
    }
}
