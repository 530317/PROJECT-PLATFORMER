using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger");
        audio.Play();
    }
}
