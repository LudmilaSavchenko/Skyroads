using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Score
    private int currentScore;
    [SerializeField] private int timePoint = 1;  //очки что даются за 1 секунду времени
    [SerializeField] private int timePointBoosted = 2; // очки во время ускорения
    public int Score
    {
        get { return currentScore; }
        set { currentScore = value; }
    }

    //Time
    private float miliSecond; //поле для подсчета милисекунд
    private int seconds; //секунду с начала уровня
    private int minutes; //минуты с начала уровня
    private const int secondsInMinute = 60; //секунд в минуте

    public string CurrentTime
    {
        get { return minutes + ":" + seconds; }
        set { }
    }
    public int Seconds
    {
        get { return seconds; }
        set { }
    }

    //Asteroids - обновляются из скрипта Asteroid
    private int asteroids;
    public int AsteroidsCount
    {
        get { return asteroids; }
        set { asteroids = value; }
    }

    //Boost
    private string boostMessage;
    public string BoostMessage
    {
        get { return BoostMessage; }
        set { }
    }
    //BestScore
    private int bestScore;
    private bool newBestScore = false;

    public int BestScore
    {
        get { return bestScore; }
        set { }
    }
    public bool NewBestScore
    {
        get { return newBestScore; }
        set { }
    }

    public static GameManager Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("Score");
    }

    void FixedUpdate()
    {   //Делаем таймер 
        miliSecond += Time.fixedDeltaTime;

        //Обновляем время и баллы за движение
        if (miliSecond >= 1.0f)
        {
            UpdateTime();
            UpdateScore();
        }

        UpdateBoostMessage();
        CheckBestScore();
    }

    private void UpdateBoostMessage()
    {
        if (ShipMovement.Instance.IsReadyToBoost)
        {
            boostMessage = "Press spacebar to speed up";
        }
        else if (ShipMovement.Instance.IsBoosted)
        {
            boostMessage = "Acceleration is active";
        }
        else
        {
            boostMessage = "Acceleration not available";
        }
    }
    private void UpdateTime()
    {
        seconds++;
        if (seconds == secondsInMinute)
        {
            minutes++;
            seconds -= secondsInMinute;
        }
        miliSecond--;
    }
    private void UpdateScore()
    {
        if (ShipMovement.Instance.IsBoosted)
            currentScore += timePointBoosted;
        else
            currentScore += timePoint;
    }
    private void CheckBestScore()
    {
        if (bestScore < currentScore) 
        {
            PlayerPrefs.SetInt("Score", currentScore);
            newBestScore = true;
        }
    }
    public void RestartGameManager()
    {
        //Score
        currentScore = 0;

        //Time
        miliSecond = 0;
        seconds = 0;
        minutes = 0;

        //Asteroids
        asteroids = 0;

        //Boost
        boostMessage = string.Empty;

        //BestScore
        bestScore = PlayerPrefs.GetInt("Score");
        newBestScore = false;
    } 
}  
