using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XboxCtrlrInput;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;

    public bool paused = false;


    void Update()
    {
        if(XCI.GetButtonDown(XboxButton.Start) && paused == false)
        {
            Pause();
        }
        else if(XCI.GetButtonDown(XboxButton.Start) && paused == true)
        {
            Resume();
        }
    }

    private void Pause()
    {
        paused = true;
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Resume()
    {
        paused = false;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
