using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool interact = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && interact)
        {
            Debug.Log("Hello");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interact = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interact = false;
    }
}
