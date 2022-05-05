using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteract : MonoBehaviour
{
    public Light _light;
    public Text interactText;
    public GameObject _object;
    public bool interact = false;
    bool isHolding = false;
    bool isNight = false;
    GameObject[] pirates;
    // Start is called before the first frame update
    void Start()
    {
       pirates = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        //Pick up nearby object
        if(Input.GetButtonDown("Interact") && interact && _object != null && !isHolding)
        {
            if (_object.name != "SwitchCube" && isNight)
            {
                _object.transform.parent = transform;
                _object.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                interactText.gameObject.SetActive(false);
                isHolding = true;
            }
            else if(_object.name != "SwitchCube" && !isNight)
            {
                interactText.text = "This is a ball";
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
        else if(Input.GetButtonDown("Interact") && isHolding)
        {
            _object.transform.parent = null;
            isHolding = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            interactText.gameObject.SetActive(true);
            interact = true;
            _object = other.gameObject;
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
        }
    }
}
