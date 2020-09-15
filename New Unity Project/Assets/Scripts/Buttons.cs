using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject CanvasGamePlay;
    [SerializeField] private GameObject CanvasGameLosig;

    public void onClickPause()
    {
        if (Time.timeScale > 0)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void onClickRestart()
    {
        //GameManager.Instance.RestartGameManager();
        //AsteroidSpawner.Instance.RestartAsteroidSpawner();
        //GenerateFloor.Instance.RestartGenerateFloor();
        //PlanetMoove.Instance.RestartPlanet();

        Time.timeScale = 1;
    }
}
