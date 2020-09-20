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

        GameObject canvasPlay;

        canvasPlay = GameObject.FindGameObjectWithTag("CanvasPlay");
        canvasPlay.transform.localScale = new Vector3(1, 1, 1);

        GameObject canvasLose;

        canvasLose = GameObject.FindGameObjectWithTag("CanvasLose");
        canvasLose.transform.localScale = new Vector3(0, 0, 0);

        Time.timeScale = 1;
    }
}
