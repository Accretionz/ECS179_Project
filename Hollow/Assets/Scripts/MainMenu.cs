using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        try
        {
            SceneManager.LoadScene("SampleScene");
            AudioManager.instance.PlayBgmTrack("BGM1");
        }
        catch (Exception e)
        {
            Debug.Log("exception");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
