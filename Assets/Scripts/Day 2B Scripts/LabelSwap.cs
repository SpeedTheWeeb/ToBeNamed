using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelSwap : MonoBehaviour
{
    public bool isInteractable;

    // leadIncomplete checks whether any leads have been completed
    public bool leadIncomple = true;
    public GameObject Labels;
    public GameObject SwappedLabels;
    public GameObject interactedObj;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable && leadIncomple) 
        {
            Labels.SetActive(false);
            SwappedLabels.SetActive(true);
            leadIncomple = false;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
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