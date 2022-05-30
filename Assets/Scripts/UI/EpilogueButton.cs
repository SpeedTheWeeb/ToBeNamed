using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class EpilogueButton : MonoBehaviour
{
    AudioManager audioManager;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    public void QuitToMainMenu()
    {
        audioManager.StopMusic();
        SceneManager.LoadScene("mainMenu");
    }
}
