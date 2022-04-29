using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
public class NPCInteract : MonoBehaviour
{
    public static readonly string tFolder = "Assets/Text/Interact/";
    public static readonly string iFolder = "Pictures/";
    public string sceneChecker;
    public RawImage uiImg;
    //public RawImage ImageB;
    string npcPrefab;
    string[] text;
    string[] line;
    bool playerInteract = false;
    public GameObject canvas;
    public TextMeshProUGUI diaText;

    // Checks if in dialogue interface
    bool inDialogue = false;

    // Checks if it's time to switch character
    bool _chara = false;

    //Check íf it's still the current character talking
    bool _line = false;


    int currentLine = 0;
    int currentDia = 0;
    // Start is called before the first frame update
    void Start()
    {
        npcPrefab = transform.name;
        text = File.ReadAllLines(tFolder + npcPrefab + "Dia.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && playerInteract && !_line)
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && _line)
        {
            NextLine();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInteract = false;
        }
    }
    void PauseGame()
    {
        canvas.SetActive(true);
        Time.timeScale = 0f;
        StartDialouge();
    }

    void StartDialouge()
    {
        inDialogue = true;
        NextCharacter();
    }

    void NextLine()
    {
        if(line.Length == currentLine)
        {
            _line = false;
            currentLine = 0;
            NextCharacter();
        }

        diaText.text = line[currentLine];
        Debug.Log(currentDia+" " +currentLine);
        currentLine++;
    }

    void NextCharacter()
    {
        if(currentDia == text.Length)
        {
            EndScene();
        }
        string[] nameSplitter = text[currentDia].Split(':');
        Texture io = Resources.Load(iFolder + nameSplitter[0]) as Texture;
        uiImg.texture = io;
        if(nameSplitter[1].Contains("_"))
        {
            line = nameSplitter[1].Split('_');
        }
        else
        {
            line = new string[] { nameSplitter[1]};
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
