using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutRope : MonoBehaviour
{
    public bool isInteractable;
    GameObject interactedObj;
    public GameObject sChanger;
    SceneChanger changer;
    // Start is called before the first frame update
    void Start()
    {
        changer = sChanger.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && isInteractable)
        {
            Debug.Log(interactedObj.name);
            switch(interactedObj.name)
            {
                case "Knife":
                    changer.getResult = 1;
                    break;
                case "Potion":
                    changer.getResult = 2;
                    break;
            }
            gameObject.SetActive(false);
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
}
