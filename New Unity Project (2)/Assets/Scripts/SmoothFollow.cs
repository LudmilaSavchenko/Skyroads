﻿using UnityEngine;
using UnityEngine.UI;

public class SmoothFollow : MonoBehaviour
{
    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public Transform target = ShipMovement.Instance.transform;
    private void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
        {
            return;
        }

        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        var pos = transform.position;
        pos = target.position - currentRotation * Vector3.forward * distance;
        pos.y = currentHeight;
        transform.position = pos;

        // Always look at the target
        transform.LookAt(target);
        //transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotationDamping * Time.deltaTime);
    }

    [SerializeField] private Text speedBoosted;
    [SerializeField] private float minimalDistance;
    private float maximumDistance;
    [SerializeField] private float minimalHeight;
    private float maximumHeight;
    [SerializeField] private float speed = 0.05f;


    void Start()
    {
        maximumDistance = distance;
        maximumHeight = height;
    }
    void Update()
    {
        if (speedBoosted.text == "Acceleration is active" && distance > minimalDistance)
        {
            distance -= speed;
            height -= (speed * 0.5f);
        }
        else if (distance < maximumDistance)
        {
            distance += speed;
            height += (speed * 0.5f);
        }
    }
}