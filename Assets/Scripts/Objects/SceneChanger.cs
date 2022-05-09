using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    Scene currentScene;
    public GameObject robe;
    public int getResult = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        switch(currentScene.name)
        {
            case "Day 1":
                DontDestroyOnLoad(gameObject);
                if(getResult != 0)
                {
                    SceneManager.LoadScene("Day 2A");
                }
                else if(getResult == 0)
                {
                    SceneManager.LoadScene("Day 2B");
                }
                break;
            case "Day 2A":
                break;
            case "Day 2B":
                break;
        }
    }
}
