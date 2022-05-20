using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixSoup : MonoBehaviour
{
    public bool isInteractable;
    public GameObject interactedObj;
    public GameObject Effect;
    FMODOneShots fmodSFX;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            Effect.gameObject.SetActive(true);
            //fmodSFX.SFXOneShots();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object") && other.gameObject.name == "Antidote")
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
