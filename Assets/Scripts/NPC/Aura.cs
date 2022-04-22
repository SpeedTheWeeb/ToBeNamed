using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class Aura : MonoBehaviour
{
    public static readonly string folder = "Assets/Text/";
    public string[] text;
    public Text hoverText;
    string npcPrefab;
    public bool inAura = false;
    // Start is called before the first frame update
    void Start()
    {
        npcPrefab = transform.parent.name;
        text = File.ReadAllLines(folder + npcPrefab+".txt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {            
        if(other.tag == "Player")
        {        
            if(text.Length != 0)
            {
                foreach(string t in text)
                {
                    hoverText.text = t;
                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        hoverText.text = "";
    }
}
