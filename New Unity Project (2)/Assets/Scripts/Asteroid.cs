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

    void Update()
    {
        if (transform.position.z < ShipMovement.Instance.transform.position.z && !isPointAdded)
        {
            GameManager.Instance.Score += asteroidPoint;
            GameManager.Instance.AsteroidsCount++;
            isPointAdded = true;
        }
        else if (transform.position.z +distanceToDestroyAsteroid < ShipMovement.Instance.transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
