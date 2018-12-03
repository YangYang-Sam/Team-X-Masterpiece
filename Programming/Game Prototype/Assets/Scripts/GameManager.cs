using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject victoryScreenUI;

    [SerializeField]
    private Text timerText;
    private float startTime;

    private bool timeAlreadyPaused = false;

    private bool victorious = false;


    // Use this for initialization
    void Start ()
    {
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + "  minutes and  " + seconds + "  seconds!";

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
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
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
