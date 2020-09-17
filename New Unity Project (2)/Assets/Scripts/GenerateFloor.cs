using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFloor : MonoBehaviour
{
    public GameObject FloorPrefabs;
    [SerializeField] private int floorLenght;
    public List<SpawnFloor> ins = new List<SpawnFloor>();
    private float LastDistance;
    [SerializeField] private int startFloorQuantity;
    public bool isDead;
    public int floorCount;
    void Start()
    {
            do
            {
            SpawnFloor();
            } while (floorCount < startFloorQuantity);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {

        }
        else
        {
            LastDistance = Vector3.Distance(ShipMovement.Instance.transform.position, ins[0].instantiated.transform.position);

            if (ins.Count < startFloorQuantity)
            {
                SpawnFloor();
            }

            if (LastDistance>= floorLenght * 5)
            {
                Destroy(ins[0].instantiated);
                ins.Remove(ins[0]);
            }
        }
    }

    private void SpawnFloor()
    {
        GameObject temp = (GameObject)Instantiate(FloorPrefabs, new Vector3(0, 0, floorCount * floorLenght), Quaternion.identity);
        SpawnFloor floor = new SpawnFloor();
        floor.instantiated = temp;
        ins.Add(floor);
        floorCount++;
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