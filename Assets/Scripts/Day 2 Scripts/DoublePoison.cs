using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoison : MonoBehaviour
{
    public GameObject PoisonTrail;
    public GameObject Light;
    bool isInteractable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            Light.SetActive(false);
            PoisonTrail.SetActive(true);
            Destroy(gameObject.GetComponent<Collider>());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Poison")
        {
            transform.tag = "Untagged";
            isInteractable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Poison")
        {
            transform.tag = "Object";
            isInteractable = false;
        }
    }
}
