using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float startSpeed = 5.0f; //Начальная скорость
    [SerializeField] private float currentSpeed; //текущая скорость
    [SerializeField] private float acceleration = 2.0f; //ускорение
    [SerializeField] private float timeBoosted = 5.0f; //продолжительность буста
    private float currentTimeBoosted; //текущее вре
    [SerializeField] private float speedBooster = 2.0f; //ускорение скорость в бусте
    [SerializeField] private bool isBoosted = false; //включен ли буст в данный момент

    [SerializeField] private bool isPlayScene = false;
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

    private Vector3 moveDirection;
    private float startYPossition;
    [SerializeField] private float stepToReturnYPossition = 0.05f;

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

    void Start()
    {
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
    //}

    //void Update()
    //{
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > -roadBorder)
        {
            //if (transform.position.x > -roadBorder)
                moveDirection = new Vector3(-1 / currentSpeed * startSpeed, 0, 1);
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (transform.position.x < roadBorder))
        {
            //if (transform.position.x < roadBorder)
                moveDirection = new Vector3(1 / currentSpeed * startSpeed, 0, 1);

        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isReadyToBoost) //Input.GetKeyDown(KeyCode.Space
        {
            moveDirection = new Vector3(0, 0, 1);

            isBoosted = true;
            isReadyToBoost = false;
        }
        else
        {
            moveDirection = new Vector3(0, 0, 1);
        }
      
            //расчет текущей скорости
            if (gameManager != null)
                currentSpeed = startSpeed + acceleration * (gameManager.Seconds + gameManager.Minutes*60) * Time.fixedDeltaTime;
            else
                currentSpeed = startSpeed;

        // проверка на буст
        if (isBoosted)
        {
            currentSpeed *= speedBooster;
        }

        if (Math.Round(transform.position.y,1) < startYPossition)
            moveDirection.y = stepToReturnYPossition;
        if (Math.Round(transform.position.y, 1) > startYPossition)
            moveDirection.y = -stepToReturnYPossition;

        this.transform.Translate(moveDirection * Time.deltaTime * currentSpeed);
    }

    public void RestertShipMovement()
    {
        currentSpeed = startSpeed;
        isBoosted = false;
        isReadyToBoost = true;
        currentTimeBoosted = timeBoosted;
    }

}
