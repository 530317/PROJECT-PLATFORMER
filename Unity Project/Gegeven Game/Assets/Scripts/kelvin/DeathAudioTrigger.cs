using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger");
        audio.Play();
        StartCoroutine(death());
    }
    IEnumerator death()
    {
        yield return new WaitForSeconds(1f);
        Destroy(player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
