using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayChecker : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().FMODDayChecker();
    }
}
