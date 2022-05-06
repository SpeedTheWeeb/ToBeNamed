using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInteract : MonoBehaviour
{
    public string day;
    public static readonly string Folder = "Text/Player/";
    public GameObject objSpawnPoint;
    public Light _light;
    public TextMeshProUGUI interactText;
    public GameObject _object;
    public bool interact = false;
    public bool isHolding = false;
    bool isNight = false;
    GameObject[] pirates;
    GameObject holdingObj;
    string sc = "";
    // Start is called before the first frame update
    void Start()
    {
       pirates = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        //Pick up nearby object
        if(Input.GetButtonDown("Interact") && interact && _object != null && !isHolding && holdingObj == null)
        {
            if (_object.name != "SwitchCube" && isNight)
            {
                holdingObj = _object;
                holdingObj.transform.parent = transform;
                holdingObj.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
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
                if(!isNight)
                {
                    Debug.Log("Is Night");
                    _light.color = new Color(34f/255f, 31f/255f, 185f/255f);
                    foreach(GameObject allPirate in pirates)
                    {
                        allPirate.SetActive(false);
                    }
                          
                    isNight = true;
                }
                else
                {
                    Debug.Log("Is Day");
                    _light.color = new Color(248f/255f, 211f/255f, 81f/255f);
                    foreach (GameObject allPirate in pirates)
                    {
                        allPirate.SetActive(true);
                    }
                    isNight = false;
                }
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
