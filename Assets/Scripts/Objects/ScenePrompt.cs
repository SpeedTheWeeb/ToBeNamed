using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScenePrompt : MonoBehaviour
{
    public GameObject scriptobj;
    TimeChanger time;
    public GameObject promtCanvas;
    public Button YesBut;
    public Button NoBut;
    // Start is called before the first frame update
    void Start()
    {
        time = scriptobj.GetComponent<TimeChanger>();
        YesBut.onClick.AddListener(YesClick);
        NoBut.onClick.AddListener(NoClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void YesClick()
    {
        promtCanvas.SetActive(false);
        time.changeTime();
        Time.timeScale = 1;
    }
    void NoClick()
    {
        promtCanvas.SetActive(false);
        Time.timeScale = 1;
    }

}
