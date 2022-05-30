using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelSwap : MonoBehaviour
{
    public bool isInteractable;

    // leadIncomplete checks whether any leads have been completed

    public GameObject Labels;
    public GameObject SwappedLabels;
    public GameObject interactedObj;
    AudioManager fmodSFX;
    public GameObject sChanger;
    SceneChanger changer;
    TimeChanger time;
    // Start is called before the first frame update
    void Start()
    {
        sChanger = GameObject.Find("ScriptObj");
        changer = sChanger.GetComponent<SceneChanger>();
        time = sChanger.GetComponent<TimeChanger>();
        fmodSFX = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable && time.isNight) 
        {
            fmodSFX.SFXOneShots("label");
            Labels.SetActive(false);
            SwappedLabels.SetActive(true);
            changer.getDay2BResult = 1;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            interactedObj = other.gameObject;
            isInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactedObj = null;
        isInteractable = false;
    }
}
