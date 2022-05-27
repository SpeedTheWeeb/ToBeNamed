using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject tpPoint;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TPObj")
        {
            Debug.Log(tpPoint.transform.position);
            RuntimeManager.PlayOneShot("event:/sfx/oneshot/open_door");
            Player.transform.position = tpPoint.transform.position;
            if(tpPoint.name == "UnderUpperTP" || tpPoint.name == "UpperTP")
                FindObjectOfType<AudioManager>().FMODToggleDeck();
        }
    }
}
