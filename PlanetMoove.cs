using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoove : MonoBehaviour
{
    [SerializeField] private Transform spaceship;
    private float startZPosition;
    void Start()
    {
        //Запоминаем позицию по z, чтобы было постоянно расстояние между кораблем и планетой
        startZPosition = transform.position.z;
    }
    void Update()
    {
        if (spaceship!=null)
        transform.position = new Vector3(transform.position.x, transform.position.y, spaceship.transform.position.z + startZPosition);
    }
}
