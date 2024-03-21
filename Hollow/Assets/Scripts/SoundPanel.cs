using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * Adapted from "Unity AUDIO MANAGER Tutorial" by Rehope Games:
 * https://www.youtube.com/watch?v=rdX7nhH6jdM
 * Adapted from "PAUSE MENU in Unity" by Brackeys:
 * https://www.youtube.com/watch?v=JivuXdrIHK0
 * 
 * Audio assets from: https://gamedeveloperstudio.itch.io/icon-pack
 * Button assets from: https://byandrox.itch.io/crimson-fantasy-gui,
 * https://gamedeveloperstudio.itch.io/icon-pack
 */

public class SoundPanel : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject panel;

    void Awake()
    {
        Debug.Log("Script Works--Awake");
    }

    void Start()
    {
        Debug.Log("Script Works--Start");
    }


    private void Update()
    {
        Debug.Log("Script Works--Update");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape button pressed");
            if (GameIsPaused)
            {
                Debug.Log("Now resume game");
                Resume();
            }
            else
            {
                Debug.Log("Now pause game");
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        // timeScale = 1, time passes as fast as real time
        // timeScale = 0.5, time passes 2x slower than realtime
        // timeScale = 0, game paused
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /*
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu...");
        //SceneManager.LoadScene("Menu");
    }

    // To Quit Scene
    public void QuitGame()
    {
        Debug.Log("Quiting game...");
        Application.Quit();
    }

    // Back to main menu button
    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        // main menu sceneID = 0
        SceneManager.LoadScene(sceneID);
    }
    */
    

    //-------------------For toggle button and sliders--------------------------
    public void ToggleBgm()
    {
        AudioManager.instance.ToggleBgm();
    }

    public void ToggleSfx()
    {
        AudioManager.instance.ToggleSFX();
    }

    public void BgmVolume()
    {
        AudioManager.instance.Bgmvolume(bgmSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }
}
