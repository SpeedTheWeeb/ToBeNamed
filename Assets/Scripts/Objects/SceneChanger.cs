using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public GameObject[] gameObjects;
    Scene currentScene;
    public GameObject robe;
    public int getDay1Result = 0;
    public int getDay2AResult = 0;
    public int getDay2BResult = 0;
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
        foreach(var obj in gameObjects)
        {
            DontDestroyOnLoad(obj);
        }
        
        switch (currentScene.name)
        {
            case "Day 1":
                if(getDay1Result != 0)
                {
                    //Reaction on Cut Rope
                    SceneManager.LoadScene("Day 2A");
                }
                else if(getDay1Result == 0)
                {
                    //Reaction on no cut rope
                    SceneManager.LoadScene("Day 2B");
                }
                break;
            case "Day 2A":
                switch(getDay2AResult)
                {
                    case 1:
                        //Reaction on healed soup
                        break;
                    case 2:
                        //Reaction on Swapped Soup
                        break;
                    case 3:
                        //Reaction on both soups poisoned
                        break;
                    default:
                        break;
                }
                break;
            case "Day 2B":
                switch(getDay2BResult)
                {
                    case 1:
                        //Reaction on swapped labels
                        break;
                    case 2:
                        //Reaction on trawl net
                        break;
                }
                break;
        }
    }
}
