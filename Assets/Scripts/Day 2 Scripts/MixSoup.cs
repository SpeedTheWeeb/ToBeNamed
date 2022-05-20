using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixSoup : MonoBehaviour
{
    public bool isInteractable;
    public GameObject interactedObj;
    public GameObject Effect;
    GameObject player;
    PlayerInteract pi;
    FMODOneShots fmodSFX;


    // Start is called before the first frame update
    void Start()
    {
        fmodSFX = GameObject.Find("AudioManager").GetComponent<FMODOneShots>();
        player = GameObject.Find("Captain5");
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
                    Effect.gameObject.SetActive(false);
                    fmodSFX.SFXOneShots("pot_bubble");
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
