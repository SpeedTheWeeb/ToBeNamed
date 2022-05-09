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
    SceneChanger changer;
    // Start is called before the first frame update
    void Start()
    {
        pirates = GameObject.FindGameObjectsWithTag("NPC");
        changer = gameObject.GetComponent<SceneChanger>();
    }

    public void changeTime()
    {
        DontDestroyOnLoad(_light);
        if(!isNight)
        {
            Debug.Log("Is Night");
            _light.color = new Color(34f / 255f, 31f / 255f, 185f / 255f);
            foreach (GameObject allPirate in pirates)
            {
                allPirate.SetActive(false);
            }
            FindObjectOfType<AudioManager>().FMODToggleTOD();
            isNight = true;
        }
        else
        {
            //Don't uncomment yet
            changer.ChangeScene();
            Debug.Log("Is Day");
            _light.color = new Color(248f / 255f, 211f / 255f, 81f / 255f);
            foreach (GameObject allPirate in pirates)
            {
                allPirate.SetActive(true);
            }
            FindObjectOfType<AudioManager>().FMODToggleTOD();
            isNight = false;
        }
    }
}
