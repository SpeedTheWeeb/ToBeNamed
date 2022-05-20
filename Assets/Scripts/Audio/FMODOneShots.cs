using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODOneShots : MonoBehaviour
{
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
}
