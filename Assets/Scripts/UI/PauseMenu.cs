using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject tutText;
    public GameObject tutMenuUI;
    AudioManager audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (GameIsPaused) 
            {
                Resume();
            } else 
            {
                Pause();
            }
        }

        if (Input.GetKey(KeyCode.Q)) 
        {
            tutMenuUI.SetActive(true);    
            tutText.SetActive(false);
        } else {
            tutMenuUI.SetActive(false);
        }
    }

    public void Resume () 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause () 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit ()
    {
        audioManager.StopMusic();
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainMenu");
    }
}
