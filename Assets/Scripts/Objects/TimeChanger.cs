using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimeChanger : MonoBehaviour
{
    public bool isNight;
    GameObject[] pirates;
    GameObject[] Lights;
    public Light _light;
    SceneChanger changer;
    public GameObject sleepingCrew;
    GameObject Crew;
    GameObject[] nightObjs;
    public Color nightColor = new Color(34f / 255f, 31f / 255f, 185f / 255f);
    public Color dayColor = new Color(255 / 255f, 255 / 255f, 255 / 255f);
    // Start is called before the first frame update
    void Start()
    {
        nightObjs = GameObject.FindGameObjectsWithTag("Night");
        changer = gameObject.GetComponent<SceneChanger>();
        foreach(GameObject g in nightObjs)
        {
            g.SetActive(false);
        }
    }

    public void changeTime()
    {
        pirates = GameObject.FindGameObjectsWithTag("NPC");
        Lights = GameObject.FindGameObjectsWithTag("Light");
        DontDestroyOnLoad(_light);
        if(!isNight)
        {
            foreach (GameObject g in nightObjs)
            {
                g.SetActive(true);
            }
            foreach(GameObject light in Lights)
            {
                Light l = light.GetComponent<Light>();
                l.color = Color.black;
            }
            Crew = GameObject.Find("Crew");
            Debug.Log("Is Night");
            _light.color = new Color(0,0,0);
            foreach (GameObject allPirate in pirates)
            {
                allPirate.SetActive(false);
            }
            FindObjectOfType<AudioManager>().FMODToggleTOD();
            isNight = true;
            sleepingCrew.SetActive(true);
        }
        else
        {
            //Day Time

            //Don't uncomment yet
            sleepingCrew.SetActive(false);
            changer.ChangeScene();
            Debug.Log("Is Day");
            _light.color = dayColor;
            foreach (GameObject allPirate in pirates)
            {
                allPirate.SetActive(true);
            }
            FindObjectOfType<AudioManager>().FMODToggleTOD();
            isNight = false;
        }
    }
}
