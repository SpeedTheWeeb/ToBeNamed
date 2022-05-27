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
    public GameObject sChanger;
    SceneChanger changer;
    FMODOneShots fmodSFX;

    // Start is called before the first frame update
    void Start()
    {
        sChanger = GameObject.Find("ScriptObj");
        fmodSFX = GameObject.Find("AudioManager").GetComponent<FMODOneShots>();
        changer = sChanger.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable) 
        {
            changer.getDay2BResult = 1;
            Destroy(gameObject.GetComponent<Collider>());
            //fmodSFX.SFXOneShots("label");
            Labels.SetActive(false);
            SwappedLabels.SetActive(true);
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
