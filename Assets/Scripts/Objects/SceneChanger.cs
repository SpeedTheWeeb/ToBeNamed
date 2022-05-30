using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public GameObject[] gameObjects;
    Scene currentScene;
    public string scenename;
    public GameObject robe;
    public int getDay1Result = 0;
    public int getDay2AResult = 0;
    public int getDay2BResult = 0;
    public string reactionResult = "";
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        scenename = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        currentScene = SceneManager.GetActiveScene();
        scenename = currentScene.name;
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
                    case 0:
                        //Reaction on Poison play
                        reactionResult = "poisonSuccess";
                        break;
                    case 1:
                        //Reaction on healed soup
                        reactionResult = "healSoup";
                        break;
                    case 2:
                        //Reaction on Swapped Soup
                        reactionResult = "swapSoup";
                        break;
                    case 3:
                        //Reaction on both soups poisoned
                        reactionResult = "bothPoison";
                        break;
                }
                SceneManager.LoadScene("Day 3");
                break;
            case "Day 2B":
                switch(getDay2BResult)
                {
                    case 0:
                        //Reaction on dumped resource
                        reactionResult = "foodDumped";
                        break;
                    case 1:
                        //Reaction on swapped labels
                        reactionResult = "swapLabel";
                        break;
                    case 2:
                        //Reaction on trawl net
                        reactionResult = "trawlNet";
                        break;
                }
                SceneManager.LoadScene("Day 3");
                break;
        }
    }
}
