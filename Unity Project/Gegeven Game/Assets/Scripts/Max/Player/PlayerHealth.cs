﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XboxCtrlrInput;
using DG.Tweening;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Damagable
{
    public float oxygenLvl;

    public float damageCooldown;

    [Header("Sliders")]
    public Slider oxygenSlider;
    public Slider healthSlider;

    CinemachineVirtualCamera vcam;
    CinemachineBasicMultiChannelPerlin noise;


    [SerializeField]private bool isTakingDamage;

    PauseMenu pauseMenu;

    [SerializeField] private AudioSource audio;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();

        vcam = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        noise = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
        StartCoroutine(OxygenTime(100, 1, 0.05f));

        if (isTakingDamage)
        {
            StartCoroutine(DamageCooldown(damageCooldown));
        }

        if (oxygenLvl <= 0)
        {
            StopCoroutine("OxygenTime");
            StartCoroutine(BloodLossTime(1000, 1, 0.05f));
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        oxygenSlider.value = oxygenLvl;
        healthSlider.value = health;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlantStem"))
        {
            if (health > 0)
            {
                if(isTakingDamage == false)
                {
                    PlayerDamage(5f);
                    gameObject.tag = "NoDamage";

                    StartCoroutine(DamageCooldown(2f));
                }


                //audio.Play();
                //PlayerDamage(5f);
                //isTakingDamage = true;
                //StartCoroutine(CameraShake(2, 2));

                //if(isTakingDamage == true)
                //{
                //    PlayerDamage(0f);
                //    StartCoroutine(DamageCooldown(2f));
                //}
            }
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (collision.CompareTag("oxygenTank"))
        {
            AddOxygen(25f);
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("DeathBarrier"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Spikes"))
        {
            audio.Play();
            PlayerDamage(3f);
            //transform.DOPunchPosition(new Vector3(1f, 0f), 1f);
            if (transform.position.y < collision.transform.position.y)
            {
                transform.DOMoveX(collision.transform.position.x - 2, 0.5f);
            }
            else
            {
                transform.DOMoveY(collision.transform.position.y + 4, 1f);
                print("up");
            }
        }
        if (collision.CompareTag("DeathBarrier"))
        {
            for (int i = 0; i < 60; i++)
            {
                PlayerDamage(100f);
            }

        }
    }

    private IEnumerator CameraShake(float amplitudeGain, float frequencyGain)
    {
        isTakingDamage = true;

        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;

        yield return new WaitForSeconds(2f);

        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
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

        gameObject.tag = "Player";
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
