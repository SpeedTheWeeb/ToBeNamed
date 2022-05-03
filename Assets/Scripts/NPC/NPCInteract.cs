using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
public class NPCInteract : MonoBehaviour
{

    GameObject textObj;
    public string sceneChecker;
    bool playerInteract = false;
    void Start()
    {
        textObj = GameObject.Find("ScriptObj");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInteract)
        {
            StartDia();
        }
    }
    void StartDia()
    {
        DialogueScript dialogue = textObj.GetComponent<DialogueScript>();
        dialogue.StartDialogue(sceneChecker);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInteract = false;
        }
    }
}
