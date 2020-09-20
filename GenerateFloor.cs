using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{
    [SerializeField] private GameObject floorPrefabs;
    [SerializeField] private GameObject spaceship;
    [SerializeField] private int floorLenght; //длина префаба. мб нужно повесить что-то на него, чтотбы узнавать конец прифаба.
    [SerializeField] private int startFloorQuantity;
    public List<SpawnFloor> ins = new List<SpawnFloor>();
    //public float LastDistance;
    public long floorCount;

    void Start()
    {
        GenerateStartFloor();
    }

    void Update()
    {
        //Вычисляем длину от "первого" блока до корабля
        //LastDistance = Vector3.Distance(spaceship.transform.position, ins[0].instantiated.transform.position);

        //если длина от "первого" блока до корабля больше 5. то говорим ему пока
        if (spaceship.transform.position.z > ins[0].instantiated.transform.position.z + floorLenght * 2) //if (LastDistance >= floorLenght * 2)
        {
            Destroy(ins[0].instantiated);
            ins.Remove(ins[0]);
        }

        //Если в списке блоков меньше, чем начальное количество, то создаем новый блок
        if (ins.Count < startFloorQuantity)
        {
            SpawnFloor();
        }

    }

    private void SpawnFloor()
    {

        GameObject temp = (GameObject)Instantiate(floorPrefabs, new Vector3(0, 0, floorCount * floorLenght), Quaternion.identity);
        temp.transform.parent = transform;
        SpawnFloor floor = new SpawnFloor();      
        floor.instantiated = temp;
        ins.Add(floor);
        floorCount++;
    }

    private void GenerateStartFloor()
    {
        do
        {
            SpawnFloor();
        } while (floorCount < startFloorQuantity);
    }

    private void DeletAllFloor()
    {
        var listLenth = ins.Count;

        for (int i = 0; i <=listLenth; i++)
        {
            Destroy(ins[0].instantiated);
            ins.Remove(ins[0]);
        }
    }
    public void RestartGenerateFloor()
    {
        floorCount = 0;
        DeletAllFloor();

    }

}
[System.Serializable]
public class Variant
{
    public GameObject model;
}

public class SpawnFloor
{
    public GameObject instantiated;   
}