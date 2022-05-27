using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class Epilogue : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public GameObject sChanger;
    SceneChanger changer;
    public static readonly string Folder = "Text/Epilogue/";
    // Start is called before the first frame update
    void Start()
    {        
        sChanger = GameObject.Find("ScriptObj");
        changer = sChanger.GetComponent<SceneChanger>();
        var file = Resources.Load<TextAsset>(Folder + changer.reactionResult);
        var content = file.text;
        Text.text = content;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
