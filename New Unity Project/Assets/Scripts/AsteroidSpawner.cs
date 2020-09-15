using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float distanceFromShip = 100f;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private GameObject asteroidPrefab;
    private int asteroidCounter;

    //ждать spawnRate +- variance секунд перед созданием нового астероида
    [SerializeField] private float spawnRate = 4.0f;
    [SerializeField] private float variance = 1.0f;

    //значение false запрещает создание астероидов
    public bool spawnAsteroids = true;
    public static AsteroidSpawner Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Запустить сопрограмму создания астероидов
        StartCoroutine(CreateAsteroids());
    }

    IEnumerator CreateAsteroids()
    {
        while (true)
        {
            //Определить место появления следующего астероида
            float nextSpawnTime = spawnRate + UnityEngine.Random.Range(-variance, variance) - asteroidCounter * Time.fixedDeltaTime;
            
            //Ждать в течение заданного интервала времени
            yield return new WaitForSeconds(nextSpawnTime);

            //Также дождаться, пока обновится физическая подчистема
            yield return new WaitForFixedUpdate();

            //Создать астероид
            CreateNewAsteroid();

            //transform.position = new Vector3(transform.position.x, transform.position.y, ship.transform.position.z + distanceFromShip);  

            //c каждым следующим астероидом будем уменьшать время между ними.
            asteroidCounter++;
        }
    }

    void CreateNewAsteroid()
    {

        if (spawnAsteroids == false)
        {
            return;
        }

        Vector3 asteroidPosition;

        //И добавить смещение объекта, порождающего астероиды
        asteroidPosition.x = UnityEngine.Random.Range(startPoint.position.x, endPoint.position.x);
        asteroidPosition.y = ShipMovement.Instance.transform.position.y;
        asteroidPosition.z = ShipMovement.Instance.transform.position.z + distanceFromShip;

        //Создать новый астероид
        GameObject newAsteroid = (GameObject)Instantiate(asteroidPrefab, asteroidPosition, Quaternion.identity);
    }

    public void DestroyAllAsteroids()
    {
        GameObject[] asteroids;

        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");

        for (int i = 0; i < asteroids.Length+1; i++)
        {
            Destroy(asteroids[i]);
        }
    }
}
