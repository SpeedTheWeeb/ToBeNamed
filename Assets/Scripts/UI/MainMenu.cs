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
        DestroyAll();
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

    public void DestroyAll() 
    {
        Destroy(GameObject.Find("Captain5"));
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("Canvas"));
        Destroy(GameObject.Find("ScriptObj"));
        Destroy(GameObject.Find("Text Canvas"));
        Destroy(GameObject.Find("SleepingCrew"));
        Destroy(GameObject.Find("Directional Light"));
        Destroy(GameObject.Find("SwitchCube"));
    }   
}
