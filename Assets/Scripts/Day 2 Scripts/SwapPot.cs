using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPot : MonoBehaviour
{
    bool isInteractable;
    public GameObject pos1;
    public GameObject pos2;
    GameObject pot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            pot.transform.position = pos2.transform.position;
            gameObject.transform.position = pos1.transform.position;
            Destroy(pot.GetComponent<Collider>());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "SafeCookingPot")
        {
            isInteractable = true;
            pot = other.gameObject;
        }
    }
}
