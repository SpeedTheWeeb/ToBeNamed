using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutRope : MonoBehaviour
{
    public bool isInteractable;
    GameObject interactedObj;
    public GameObject sChanger;
    SceneChanger changer;
    AudioManager fmodSFX;
    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        fmodSFX = GameObject.FindObjectOfType<AudioManager>();
        changer = sChanger.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && isInteractable)
        {
            if(interactedObj.name != "Key")
            {
                Debug.Log(interactedObj.name);
                switch(interactedObj.name)
                {
                    case "Cutlass":
                        changer.getDay1Result = 1;
                        fmodSFX.SFXOneShots("rope_cut");
                        break;
                    case "Candle": //NYI
                        changer.getDay1Result = 1;
                        fmodSFX.SFXOneShots("rope_burn");
                        break;
                    case "Sauce":
                        changer.getDay1Result = 2;
                        break;
                }
                interactedObj.SetActive(false);
                anchor.SetActive(false);
            }
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
