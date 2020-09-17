using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public void onClickPause()
    {
        if (Time.timeScale > 0)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void onClickRestart()
    {

    }


}
