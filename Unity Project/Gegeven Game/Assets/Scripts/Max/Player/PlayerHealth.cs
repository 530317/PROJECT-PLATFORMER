using System.Collections;
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


    [SerializeField]private bool isTakingDamage = false;

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
                PlayerDamage(10f);
                StartCoroutine(CameraShake(2,2));
                isTakingDamage = true;
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
            if (transform.position.x < collision.transform.position.x)
            {
                transform.DOMoveX(collision.transform.position.x - 2, 0.5f);
            }
            else
            {
                transform.DOMoveX(collision.transform.position.x + 2, 0.5f);
            }
        }
    }
    
    private IEnumerator CameraShake(float amplitudeGain, float frequencyGain)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;

        yield return new WaitForSeconds(0.5f);

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
