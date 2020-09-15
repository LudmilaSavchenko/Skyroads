using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour 
{
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.anyKey)
        {
            
            Application.LoadLevel("play");
        }
    }

}
