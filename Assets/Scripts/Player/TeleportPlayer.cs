using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject tpPoint;
    public GameObject Player;
    AudioManager fmodSFX;
    public Light sunLight;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        fmodSFX = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "TPObj")
        {
            sunLight = GameObject.Find("Directional Light").GetComponent<Light>();
            
            fmodSFX.SFXOneShots("open_door");
            Player = other.transform.parent.gameObject;
            Player.transform.position = tpPoint.transform.position;
            if(tpPoint.name == "UnderUpperTP" || tpPoint.name == "UpperTP" || tpPoint.name == "CabinDeckTP" || tpPoint.name == "DeckCabinTP")
                FindObjectOfType<AudioManager>().FMODToggleDeck();
            

            if(tpPoint.name == "UnderUpperTP" || tpPoint.name == "CabinDeckTP")
            {
                sunLight.color = new Color(0, 0, 0);
            }
            else if(tpPoint.name == "UpperTP" || tpPoint.name == "DeckCabinTP")
            {
                sunLight.color = new Color(1, 1, 1);
            }

        }
    }
}
