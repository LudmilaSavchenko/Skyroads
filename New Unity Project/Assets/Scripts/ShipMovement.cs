using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed = 5.0f; //Начальная скорость
    [SerializeField] private float currentSpeed; //текущая скорость
    [SerializeField] private float acceleration = 1.0f; //ускорение
    [SerializeField] private float timeBoosted = 5.0f; //продолжительность буста
    private float currentTimeBoosted; //текущее вре
    [SerializeField] private float speedBooster = 2.0f; //ускорение скорость в бусте
    [SerializeField] private bool isBoosted = false; //включен ли буст в данный момент
    public bool IsBoosted
    {
        get { return isBoosted; }
        set { }
    }
    [SerializeField] private bool isReadyToBoost = true; //готов ли буст для включения
    public bool IsReadyToBoost
    {
        get { return isReadyToBoost; }
        set { }
    }
    [SerializeField] private float recoveryRateBoost = 0.5f;

    
    public Vector3 rotation;
    private Vector3 moveDirection;
    private float startYPossition;
    [SerializeField] private float stepToReturnYPossition = 0.05f;

    public float turnRate = 6.0f;
    public float levelDamping = 1.0f;

    public const float roadBorder = 3.0f;

    public float Speed
    {
        get { return currentSpeed; }
        set
        {
            if (value > 0.5)
                startSpeed = value;
        }
    }

    public static ShipMovement Instance { get; set; }

    void Awake()
    {
        Instance=this;
    }

    void Start()
    {
        rotation = Vector3.zero;
        moveDirection = Vector3.forward;
        currentSpeed = startSpeed;
        startYPossition = transform.position.y;
        currentTimeBoosted = timeBoosted;
    }

    void FixedUpdate()
    {   
        //если включен буст, то начинаем отнимать время до его выключения
        if (isBoosted)
        {
            currentTimeBoosted -= Time.deltaTime;
            if (currentTimeBoosted <=0)
                isBoosted = false;

        }
        //откатываем буст для использования
        else if (!isReadyToBoost)
        {
            currentTimeBoosted += (Time.fixedDeltaTime * recoveryRateBoost);
            if (currentTimeBoosted >= timeBoosted)
                isReadyToBoost = true;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = new Vector3(0, 0, 0.15f);
            if (transform.position.x > -roadBorder)
                moveDirection = new Vector3(-1 / currentSpeed * startSpeed, 0, 1);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotation = new Vector3(0, 0, -0.15f);
            if (transform.position.x < roadBorder)
                moveDirection = new Vector3(1 / currentSpeed * startSpeed, 0, 1);

        }
        else if (Input.GetKeyDown(KeyCode.Space) && isReadyToBoost)
        {
            rotation = Vector3.zero;
            moveDirection = new Vector3(0, 0, 1);

            isBoosted = true;
            isReadyToBoost = false;
        }
        else
        {
            rotation = Vector3.zero;
            moveDirection = new Vector3(0, 0, 1);
        }
        //расчет текущей скорости
        currentSpeed = startSpeed + acceleration * GameManager.Instance.Seconds * Time.fixedDeltaTime;
        // проверка на буст
        if (isBoosted)
        {
            currentSpeed *= speedBooster;
        }

        if (transform.position.y < startYPossition)
            moveDirection.y = stepToReturnYPossition;

            this.transform.Translate(moveDirection * Time.deltaTime * currentSpeed);

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
