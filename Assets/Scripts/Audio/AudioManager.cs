using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Scene scene;

    public EventInstance mainBGM;
    public EventInstance creakSFX;
    public EventInstance waveSFX;
    public EventInstance windSFX;

    public float deck;
    public float night;
    public float day2;

    [HideInInspector] public PLAYBACK_STATE pbsBGM;
    [HideInInspector] public PLAYBACK_STATE pbsCreak;
    [HideInInspector] public PLAYBACK_STATE pbsWave;
    [HideInInspector] public PLAYBACK_STATE pbsWind;

    private void Awake()
    {
        ManageSingleton();
        scene = SceneManager.GetActiveScene();
        /*mainBGM = RuntimeManager.CreateInstance("event:/bgm/main");
        creakSFX = RuntimeManager.CreateInstance("event:/sfx/ambience/creak");
        waveSFX = RuntimeManager.CreateInstance("event:/sfx/ambience/waves");
        windSFX = RuntimeManager.CreateInstance("event:/sfx/ambience/wind");

        mainBGM.getPlaybackState(out pbsBGM);
        creakSFX.getPlaybackState(out pbsCreak);
        waveSFX.getPlaybackState(out pbsWave);
        windSFX.getPlaybackState(out pbsWind);

        deck = 1f;
        night = 0f;
        day2 = 0f;

        mainBGM.setParameterByName("deck", deck);
        mainBGM.setParameterByName("night", night);
        mainBGM.setParameterByName("day2", day2);
        waveSFX.setParameterByName("deck", deck);
        windSFX.setParameterByName("deck", deck);*/
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        mainBGM.getPlaybackState(out pbsBGM);
        creakSFX.getPlaybackState(out pbsCreak);
        waveSFX.getPlaybackState(out pbsWave);
        windSFX.getPlaybackState(out pbsWind);
        if (pbsBGM == PLAYBACK_STATE.STOPPED && scene.name != "mainMenu")
        {
            FMODStartBGM();
        }
    }
   
    public void FMODStartBGM()
    {
        mainBGM = RuntimeManager.CreateInstance("event:/bgm/main");
        creakSFX = RuntimeManager.CreateInstance("event:/sfx/ambience/creak");
        waveSFX = RuntimeManager.CreateInstance("event:/sfx/ambience/waves");
        windSFX = RuntimeManager.CreateInstance("event:/sfx/ambience/wind");        

        deck = 0f;
        night = 0f;
        day2 = 0f;

        mainBGM.setParameterByName("deck", deck);
        mainBGM.setParameterByName("night", night);
        mainBGM.setParameterByName("day2", day2);
        waveSFX.setParameterByName("deck", deck);
        windSFX.setParameterByName("deck", deck);

        mainBGM.start();
        creakSFX.start();
        waveSFX.start();
        windSFX.start();
    }

    public void FMODToggleTOD()
    {
        mainBGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        if (night == 0)
            night = 1f;                        
        else        
            night = 0f;        
        mainBGM.setParameterByName("night", night);        
        mainBGM.start();
    }

    public void FMODToggleDeck()
    {
        if (deck == 0)
            deck = 1f;
        else
            deck = 0f;
        mainBGM.setParameterByName("deck", deck);
    }

    public void FMODDayChecker()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Day 1")
            day2 = 0f;
        else if (scene.name == "Day 2A" || scene.name == "Day 2B")
            day2 = 1f;
        mainBGM.setParameterByName("day2", day2);
    }

    public void SFXOneShots(string eventName)
    {
        RuntimeManager.PlayOneShot("event:/sfx/oneshot/" + eventName);
        /*
         * label
         * open_door
         * pickup
         * pot_bubble
         * rats
         * rope_burn
         * rope_cut
         * unlock
         */
    }

    public void StopMusic()
    {
        mainBGM.getPlaybackState(out pbsBGM);
        creakSFX.getPlaybackState(out pbsCreak);
        waveSFX.getPlaybackState(out pbsWave);
        windSFX.getPlaybackState(out pbsWind);
        if (pbsBGM != PLAYBACK_STATE.STOPPED)
        {
            mainBGM.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            creakSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            waveSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            windSFX.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}