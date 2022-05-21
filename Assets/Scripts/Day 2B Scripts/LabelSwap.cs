using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelSwap : MonoBehaviour
{
    public bool isInteractable = true;
    public GameObject Labels;
    public GameObject SwappedLabels;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable) 
        {
            Labels.SetActive(false);
            SwappedLabels.SetActive(true);
            isInteractable = false;
        }    
    }
}
