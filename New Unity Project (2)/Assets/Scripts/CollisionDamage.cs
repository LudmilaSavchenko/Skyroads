using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] GameObject LooseCanvasPrefabs;
    private Vector3 LoosePosition = new Vector3(512.0f, 384.0f, 0.0f);
    private void OnCollisionEnter(Collision collision)
    {
        //GameObject temp = (GameObject)Instantiate(LooseCanvasPrefabs, LoosePosition, Quaternion.identity);
        Time.timeScale = 0;
    }
}
