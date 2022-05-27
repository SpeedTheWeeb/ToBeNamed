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
    FMODOneShots fmodSFX;

    // Start is called before the first frame update
    void Start()
    {
        fmodSFX = GameObject.Find("AudioManager").GetComponent<FMODOneShots>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable) 
        {
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
