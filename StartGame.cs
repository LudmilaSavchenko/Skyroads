using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour 
{
    public int firstRun = 0;
    // Update is called once per frame
    void Start()
    {
        firstRun = PlayerPrefs.GetInt("firstRun");

        if (firstRun == 0)
        {
            firstRun = 1;
            PlayerPrefs.SetInt("firstRun", firstRun);
            PlayerPrefs.SetInt("Score", 0);
            //PlayerPrefs.DeleteAll();
        }
    }
    [System.Obsolete]
    void Update()
    {
        if (Input.anyKey)
        {
            Application.LoadLevel("PlayScene");
        }
    }

}
