using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject canvasPlay;

        canvasPlay = GameObject.FindGameObjectWithTag("CanvasPlay");
        canvasPlay.transform.localScale = new Vector3(0, 0, 0);

        GameObject canvasLose;

        canvasLose = GameObject.FindGameObjectWithTag("CanvasLose");
        canvasLose.transform.localScale = new Vector3(1, 1, 1);

        Time.timeScale = 0;

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().RestartGameManager();
        GameObject.FindGameObjectWithTag("AsteroidSpawner").GetComponent<AsteroidSpawner>().RestartAsteroidSpawner();


    }
}
