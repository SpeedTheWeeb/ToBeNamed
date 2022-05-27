using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPot : MonoBehaviour
{
    bool isInteractable;
    public GameObject pos1;
    public GameObject pos2;
    GameObject pot;
    public GameObject mainPot;
    public GameObject sChanger;
    SceneChanger changer;
    // Start is called before the first frame update
    void Start()
    {
        sChanger = GameObject.Find("ScriptObj");
        changer = sChanger.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            pot.transform.position = pos2.transform.position;
            mainPot.transform.position = pos1.transform.position;
            changer.getDay2AResult = 2;
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
