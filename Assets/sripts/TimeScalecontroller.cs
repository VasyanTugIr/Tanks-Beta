using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScalecontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            Time.timeScale = 0.01f;
        }
        else
        {
            Time.timeScale = 1f;
        }
               
        
    }
}
