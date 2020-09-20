using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipRotation : MonoBehaviour
{
    public float turnRate = 6.0f;
    public float levelDamping = 1.0f;
    public Vector3 rotation;

    void Start()
    {
        rotation = Vector3.zero;  
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = new Vector3(0, 0, 0.15f);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotation = new Vector3(0, 0, -0.15f);
        }
        else
        {
            rotation = Vector3.zero;
        }

        rotation *= turnRate;
        rotation.y = Mathf.Clamp(rotation.y, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);

        var newOrientation = Quaternion.Euler(rotation);
        transform.rotation *= newOrientation;

        var levelAngles = transform.eulerAngles;
        levelAngles.z = 0.0f;
        var levelOrientation = Quaternion.Euler(levelAngles);

        transform.rotation = Quaternion.Slerp(transform.rotation, levelOrientation, levelDamping * Time.deltaTime);
    }
}
