using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpilogueButton : MonoBehaviour
{
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
