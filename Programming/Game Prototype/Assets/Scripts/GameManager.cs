﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject victoryScreenUI;

    private bool timeAlreadyPaused = false;

    private bool victorious = false;

    // Use this for initialization
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (victorious == false)
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
            if (victorious == true)
            {
                return;
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;

        if (timeAlreadyPaused == true)
        {
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
        }
        else
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }
    
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);

        if (Time.timeScale == 0f)
        {
            timeAlreadyPaused = true;
        }

        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
        }
        GameIsPaused = true;
    }

    public void Restart()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        AkSoundEngine.SetState("", "");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Victory()
    {
        victorious = true;
        victoryScreenUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("Qutting game");
        Application.Quit();
    }
}
