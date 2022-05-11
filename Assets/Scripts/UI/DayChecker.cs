using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().FMODDayChecker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
