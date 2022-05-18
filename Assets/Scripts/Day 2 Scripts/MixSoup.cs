using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixSoup : MonoBehaviour
{
    public bool isInteractable;
    GameObject interactedObj;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            Debug.Log(interactedObj.name);
            switch (interactedObj.name)
            {
                case "Antidote":
                    Effect.gameObject.SetActive(true);
                    break;
                case "Potion":
                    break;
            }
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
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
