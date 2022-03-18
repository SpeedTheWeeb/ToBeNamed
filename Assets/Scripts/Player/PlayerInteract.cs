using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteract : MonoBehaviour
{
    public Text interactText;
    GameObject _object;
    public bool interact = false;
    bool isHolding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Pick up nearby object
        if(Input.GetButtonDown("Interact") && interact && _object != null && !isHolding)
        {
            _object.transform.parent = transform;
            _object.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            interactText.gameObject.SetActive(false);
            isHolding = true;
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
        if(!other.CompareTag("Player") && !other.CompareTag("Wall"))
        {
            interactText.gameObject.SetActive(true);
            interact = true;
            _object = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player") && !other.CompareTag("Wall"))
        {
            interactText.gameObject.SetActive(false);
            interact = false;
            _object = null;
        }
    }
}
