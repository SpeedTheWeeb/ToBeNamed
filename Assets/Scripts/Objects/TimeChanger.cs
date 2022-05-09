using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeChanger : MonoBehaviour
{
    public bool isNight;
    GameObject[] pirates;
    public Light _light;
    // Start is called before the first frame update
    void Start()
    {
        pirates = GameObject.FindGameObjectsWithTag("NPC");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeTime()
    {
        if(!isNight)
        {
            Debug.Log("Is Night");
            _light.color = new Color(34f / 255f, 31f / 255f, 185f / 255f);
            foreach (GameObject allPirate in pirates)
            {
                allPirate.SetActive(false);
            }

            isNight = true;
        }
        else
        {
            Debug.Log("Is Day");
            _light.color = new Color(248f / 255f, 211f / 255f, 81f / 255f);
            foreach (GameObject allPirate in pirates)
            {
                allPirate.SetActive(true);
            }
            isNight = false;
        }
    }
}
