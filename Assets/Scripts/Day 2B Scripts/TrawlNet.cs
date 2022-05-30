using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrawlNet : MonoBehaviour
{
    public GameObject fullTrawl;
    GameObject smallTrawl;
    bool isInteract = false;
    public GameObject sChanger;
    SceneChanger changer;
    TimeChanger time;
    // Start is called before the first frame update
    void Start()
    {
        sChanger = GameObject.Find("ScriptObj");
        time = sChanger.GetComponent<TimeChanger>();
        changer = sChanger.GetComponent<SceneChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && isInteract && time.isNight)
        {
            changer.getDay2BResult = 2;
            //Destroy(gameObject.GetComponent<Collider>());
            gameObject.SetActive(false);
            smallTrawl.SetActive(false);
            fullTrawl.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Object"))
        {
            smallTrawl = other.gameObject;
            isInteract = true;
        }
    }
}
