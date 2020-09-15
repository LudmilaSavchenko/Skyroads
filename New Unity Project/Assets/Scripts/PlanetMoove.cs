using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoove : MonoBehaviour
{
    private float startZPosition;
    public static PlanetMoove Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Запоминаем позицию по z, чтобы было постоянно расстояние между кораблем и планетой
        startZPosition = transform.position.z;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, ShipMovement.Instance.transform.position.z + startZPosition);
    }

    public void restartPlanet()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startZPosition);
    }
}
