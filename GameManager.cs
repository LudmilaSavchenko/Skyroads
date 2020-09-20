using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ShipMovement shipMovement;
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
    }
    public int Seconds
    {
        get { return seconds; }
    }
    public int Minutes
    {
        get { return minutes; }
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
        get { return boostMessage; }
    }
    //BestScore
    private int bestScore;
    private bool newBestScore = false;

    public int BestScore
    {
        get { return bestScore; }
    }
    public bool NewBestScore
    {
        get { return newBestScore; }
    }

    //public static GameManager Instance { get; set; }

    //void Awake()
    //{
    //    Instance = this;
    //}
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
        if (shipMovement.IsReadyToBoost)
        {
            boostMessage = "Acceleration is available";
        }
        else if (shipMovement.IsBoosted)
        {
            boostMessage = "Acceleration is active";
        }
        else
        {
            boostMessage = "Acceleration is not available";
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
        if (shipMovement.IsBoosted)
            currentScore += timePointBoosted;
        else
            currentScore += timePoint;
    }
    private void CheckBestScore()
    {
        if (bestScore < currentScore) 
        {
            PlayerPrefs.SetInt("Score", currentScore);
            bestScore = currentScore;
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
