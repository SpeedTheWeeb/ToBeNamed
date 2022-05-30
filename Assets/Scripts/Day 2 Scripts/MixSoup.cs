using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixSoup : MonoBehaviour
{
    public bool isInteractable;
    public GameObject interactedObj;
    public GameObject Effect;
    AudioManager fmodSFX;
    public GameObject LightVFX;
    public GameObject sChanger;
    SceneChanger changer;
    TimeChanger time;
    // Start is called before the first frame update
    void Start()
    {
        sChanger = GameObject.Find("ScriptObj");
        fmodSFX = GameObject.FindObjectOfType<AudioManager>();
        time = sChanger.GetComponent<TimeChanger>();
        changer = sChanger.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable && time.isNight)
        {
            Effect.gameObject.SetActive(false);
            fmodSFX.SFXOneShots("pot_bubble");
            LightVFX.gameObject.SetActive(true);
            interactedObj.SetActive(false);
            changer.getDay2AResult = 1;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Antidote")
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
