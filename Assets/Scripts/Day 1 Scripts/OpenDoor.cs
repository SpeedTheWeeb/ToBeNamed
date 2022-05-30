using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool isInteractable;
    GameObject interactedObj;
    Vector3 rotateVector = new Vector3(0, 0, 0);
    AudioManager fmodSFX;

    // Start is called before the first frame update
    void Start()
    {
        fmodSFX = GameObject.FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            fmodSFX.SFXOneShots("open_gate");
            transform.rotation = Quaternion.Euler(rotateVector);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object") && other.name == "Key")
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
