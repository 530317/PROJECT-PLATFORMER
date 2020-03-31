using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMeneu : MonoBehaviour
{
    public void Level()
    {
        SceneManager.LoadScene("Max 3");
    }
    public void Options()
    {
        SceneManager.LoadScene("settings");
    }
    //public void Levels()
    //{
    //    SceneManager.LoadScene("levelmenu");
    //}
    public void Credits()
    {
        SceneManager.LoadScene("kelvin 1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
