using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject tpPoint;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "TPObj")
        {
            Debug.Log(tpPoint.transform.position);
            Player.transform.position = tpPoint.transform.position;
            FindObjectOfType<AudioManager>().FMODToggleDeck();
        }
    }
}
