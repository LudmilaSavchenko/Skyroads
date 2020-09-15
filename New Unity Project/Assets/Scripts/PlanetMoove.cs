using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoove : MonoBehaviour
{
    private float startZPosition;
    void Start()
    {
        //Запоминаем позицию по z, чтобы было постоянно расстояние между кораблем и планетой
        startZPosition = transform.position.z;
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, ShipMovement.Instance.transform.position.z + startZPosition);
    }

    public void RestartPlanet()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startZPosition);
    }
}
