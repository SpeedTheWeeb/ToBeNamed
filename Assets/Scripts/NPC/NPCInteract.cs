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
    SceneChanger changer;
    void Start()
    {
        textObj = GameObject.Find("ScriptObj");
        changer = textObj.GetComponent<SceneChanger>();
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
        if(sceneChecker == "d1React")
        {
            if(changer.getResult == 1)
            {
                sceneChecker = "D2Aplan.sabo";
            }
            else if(changer.getResult == 2)
            {
                sceneChecker = "D2Aplan.rats";
            }
        }
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
