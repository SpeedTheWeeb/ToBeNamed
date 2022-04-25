using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;
public class NPCInteract : MonoBehaviour
{
    public static readonly string folder = "Assets/Text/Interact/";
    public string sceneChecker;
    public Texture PirateA;
    public Texture PirateB;
    public RawImage ImageA;
    public RawImage ImageB;
    string npcPrefab;
    string[] text;
    bool playerInteract = false;
    public GameObject canvas;
    public TextMeshProUGUI diaText;
    // Start is called before the first frame update
    void Start()
    {
        npcPrefab = transform.name;
        text = File.ReadAllLines(folder + npcPrefab + "Dia.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Interact") && playerInteract)
        {
            PauseGame();
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
        PlayScene();
    }

    void PlayScene()
    {
        ImageA.texture = PirateA;
        ImageB.texture = PirateB;
        StartCoroutine(DialougeRoutine());
    }
    IEnumerator DialougeRoutine()
    {
        foreach(string dialouge in text)
        {
            diaText.text = dialouge;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        EndScene();
    }

    void EndScene()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
    }

}
