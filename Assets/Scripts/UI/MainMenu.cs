using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;
using System;

public class MainMenu : MonoBehaviour
{
    public EventInstance bgmLoop;
    PLAYBACK_STATE playbackState;
    AudioManager audiomanager;
    GameObject scriptobj;
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
        try
        {
            scriptobj = GameObject.Find("ScriptObj");
            SceneChanger scene = scriptobj.GetComponent<SceneChanger>();

            foreach(GameObject o in scene.gameObjects)
            {
                Destroy(o);
            }
            Destroy(GameObject.Find("Antidote"));
            Destroy(GameObject.Find("Poison"));
            Destroy(GameObject.Find("SafeCookingPot"));
            Destroy(GameObject.Find("Trawl"));

            Debug.Log($"Before: {scene.getDay1Result}, {scene.getDay2AResult}, {scene.getDay2BResult}");

            scene.getDay1Result = 0;
            scene.getDay2AResult = 0;
            scene.getDay2BResult = 0;

            Debug.Log($"After: {scene.getDay1Result}, {scene.getDay2AResult}, {scene.getDay2BResult}");
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
    }   
}
