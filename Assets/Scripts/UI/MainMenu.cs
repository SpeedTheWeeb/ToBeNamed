using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MainMenu : MonoBehaviour
{
    public EventInstance bgmLoop;
    PLAYBACK_STATE playbackState;
    AudioManager audiomanager;

    void Start()
    {
        audiomanager = FindObjectOfType<AudioManager>();
        bgmLoop = RuntimeManager.CreateInstance("event:/bgm/menu");
        bgmLoop.start();
        bgmLoop.getPlaybackState(out playbackState);
    }

    public void PlayGame () 
    {        
        if (playbackState != PLAYBACK_STATE.STOPPED)
            bgmLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        SceneManager.LoadScene("Day 1");
        audiomanager.FMODStartBGM();
    }

    public void QuitGame() 
    {
        if (playbackState != PLAYBACK_STATE.STOPPED)
            bgmLoop.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Application.Quit();
    }   
}
