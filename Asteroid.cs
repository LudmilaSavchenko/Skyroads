using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private int asteroidPoint = 5;  //число очков за обход астероида
    [SerializeField] private float distanceToDestroyAsteroid = 10.0f; //когда астероид буден на этом растоянии от корабля, то удаляем его
    private bool isPointAdded = false;
    private GameObject spaceship;
    private GameManager gameManager;

    void Start()
    {
        spaceship = GameObject.FindGameObjectWithTag("Spaceship");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }
    void Update()
    {
        if (spaceship != null)
        {
            if (transform.position.z < spaceship.transform.position.z && !isPointAdded)
            {
                gameManager.Score += asteroidPoint;
                gameManager.AsteroidsCount++;
                isPointAdded = true;
            }
            else if (transform.position.z + distanceToDestroyAsteroid < spaceship.transform.position.z)
            {
                Destroy(gameObject);
            }
        }
    }
}
