using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using FMOD.Studio;
public class PlayerInteract : MonoBehaviour
{
    public GameObject scriptobj;
    TimeChanger time;
    public string day;
    public static readonly string Folder = "Text/Player/";
    public GameObject objSpawnPoint;
    public TextMeshProUGUI interactText;
    public GameObject _object;
    public bool interact = false;
    public bool isHolding = false;
    bool isNight;
    public GameObject holdingObj;
    string sc = "";
    // Start is called before the first frame update
    void Start()
    {
        time = scriptobj.GetComponent<TimeChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        isNight = time.isNight;
        //Pick up nearby object
        if(Input.GetButtonDown("Interact") && interact && _object != null && !isHolding && holdingObj == null)
        {
            if (_object.name != "SwitchCube" && isNight)
            {
                RuntimeManager.PlayOneShot("event:/sfx/oneshot/pickup");
                holdingObj = _object;
                holdingObj.transform.parent = transform;
                holdingObj.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
                interactText.gameObject.SetActive(false);
                isHolding = true;
            }
            else if(_object.name != "SwitchCube" && !isNight)
            {
                var file = Resources.Load<TextAsset>(Folder + day);
                var content = file.text;
                var text = content.Split('\n');
                foreach(var t in text)
                {
                    var split = t.Split(':');
                    if(split[0] == _object.name)
                    {
                        interactText.text = split[1];
                    }
                }

            }
            else if(_object.name == "SwitchCube")
            {
                time.changeTime();
            }
        }
        //Drop holding object

        else if(Input.GetButtonDown("Interact") && isHolding && sc != "SwitchCube")
        {
            holdingObj.transform.position = new Vector3(holdingObj.transform.position.x, holdingObj.transform.position.y-3, holdingObj.transform.position.z);
            holdingObj.transform.parent = null;
            holdingObj = null;
            isHolding = false;
            _object = null;
            interact = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            interactText.gameObject.SetActive(true);
            interact = true;
            _object = other.gameObject;
            sc = other.name;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            interactText.text = "Interact";
            interactText.gameObject.SetActive(false);
            interact = false;
            _object = null;
            sc = "";
        }
    }
}
