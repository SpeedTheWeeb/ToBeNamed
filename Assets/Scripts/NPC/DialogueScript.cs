using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
public class DialogueScript : MonoBehaviour
{
    public static readonly string tFolder = "Assets/Text/Interact/";
    public static readonly string iFolder = "Pictures/";
    public string sceneChecker;
    public RawImage uiImg;
    //public RawImage ImageB;
    string[] text;
    string[] line;
    public GameObject canvas;
    public TextMeshProUGUI diaText;
    // Checks if in dialogue interface
    bool inDialogue = false;

    // Checks if it's time to switch character
    bool _chara = false;

    //Check �f it's still the current character talking
    bool _line = false;


    int currentLine = 0;
    int currentDia = 0;

    public void StartDialogue(string scene)
    {
        text = File.ReadAllLines(tFolder + scene + ".txt");
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
        inDialogue = true;
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

        diaText.text = line[currentLine];
        Debug.Log(currentDia + " " + currentLine);
        currentLine++;
    }

    void NextCharacter()
    {
        if (currentDia == text.Length)
        {
            EndScene();
        }
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
        _chara = false;
        NextLine();
    }

    void EndScene()
    {
        canvas.SetActive(false);
        currentLine = 0;
        currentDia = 0;
        Time.timeScale = 1f;
        inDialogue = false;
        _line = false;
        _chara = false;
    }
}