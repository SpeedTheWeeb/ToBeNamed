using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
public class Aura : MonoBehaviour
{
    public static readonly string folder = "Text/Auras/";
    public string[] text;
    public string npc;
    public Text hoverText;
    public string auraText;
    public bool inAura = false;
    // Start is called before the first frame update
    void Start()
    {
        var file = Resources.Load<TextAsset>(folder + auraText);
        var content = file.text;
        text = content.Split('\n');
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
