using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoison : MonoBehaviour
{
    public GameObject PoisonTrail;
    public GameObject Light;
    bool isInteractable = false;
    GameObject poison;
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
        if (Input.GetButtonDown("Interact") && isInteractable)
        {
            Light.SetActive(false);
            PoisonTrail.SetActive(true);
            Destroy(gameObject.GetComponent<Collider>());
            poison.SetActive(false);
            changer.getDay2AResult = 3;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Poison")
        {
            poison = other.gameObject;
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
