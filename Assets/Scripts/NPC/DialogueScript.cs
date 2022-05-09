using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
public class DialogueScript : MonoBehaviour
{
    public static readonly string tFolder = "Text/Interact/";
    public static readonly string iFolder = "Pictures/";
    public string sceneChecker;
    public RawImage uiImg;
    //public RawImage ImageB;
    string[] text;
    string[] line;
    public GameObject canvas;
    public TextMeshProUGUI diaText;

    //Check íf it's still the current character talking
    bool _line = false;


    int currentLine = 0;
    int currentDia = 0;

    public void StartDialogue(string scene)
    {
        currentLine = 0;
        currentDia = 0;
        var file = Resources.Load<TextAsset>(tFolder + scene);
        Debug.Log(file);
        var content = file.text;
        text = content.Split('\n');
        PauseGame();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _line)
        {
            NextLine();
        }
    }
    void PauseGame()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;        
        NextCharacter();
    }

    void NextLine()
    {
        if (line.Length == currentLine)
        {
            _line = false;
            currentLine = 0;
            NextCharacter();
        }
        else
        {
            diaText.text = line[currentLine];
            currentLine++;
        }
    }

    void NextCharacter()
    {
        if (currentDia == text.Length)
        {
            EndScene();
        }
        else
        {
            string[] nameSplitter = text[currentDia].Split(':');
            Texture io = Resources.Load(iFolder + nameSplitter[0]) as Texture;
            uiImg.texture = io;
            if (nameSplitter[1].Contains("_"))
            {
                line = nameSplitter[1].Split('_');
            }
            else
            {
                line = new string[] { nameSplitter[1] };
            }
            currentDia++;
            _line = true;
            NextLine();
        }
    }

    void EndScene()
    {        
        currentLine = 0;
        currentDia = 0;
        Time.timeScale = 1f;
        _line = false;
        canvas.SetActive(false);
    }
}
