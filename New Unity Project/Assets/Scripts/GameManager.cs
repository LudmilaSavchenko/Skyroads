using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private int points;
    public int Score
    {
        get { return points; }
        set { points = value; }
    }

    [SerializeField] private Text speed;

    [SerializeField] private Text timer;
    [SerializeField] private int seconds;
    private float miliSecond; //поле для подсчета милисекунд
    [SerializeField] private int timePoint = 1;  //очки что даются за 1 секунду времени
    [SerializeField] private int timePointBoosted = 2;
    public int Seconds
    {
        get { return seconds; }
        set { }
    }

    [SerializeField] private Text asteroidCount;
    private int asteroids;
    public int AsteroidsCount
    {
        get { return asteroids; }
        set { asteroids = value; }
    }

    [SerializeField] private Text isRadyToBoost;
    [SerializeField] private Text newBest;

    public static GameManager Instance { get; set; }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //Выводим поля
        timer.text = "Time: " + (seconds / 60) + ":" + (seconds % 60);
        score.text = " 0";
        speed.text = "Speed: " + ShipMovement.Instance.Speed;
        asteroidCount.text = "0";
        isRadyToBoost.text = "";
    }

    void FixedUpdate()
    {   //Делаем таймер 
        miliSecond += Time.fixedDeltaTime;

        //Обновляем время и баллы за движение
        if (miliSecond >= 1.0f)
        {
            seconds++;
            if (ShipMovement.Instance.IsBoosted)
            {
                points += timePointBoosted;
            }
            else
            {
                points += timePoint;
            }
            score.text = points.ToString();
            miliSecond--;

        }

        //Обновляем поля
        speed.text = "Speed: " + ShipMovement.Instance.Speed;
        timer.text = "Time: " + (seconds / 60) + ":" + (seconds % 60);
        asteroidCount.text = "Asteroids: " + asteroids;

        if (ShipMovement.Instance.IsReadyToBoost)
        {
            isRadyToBoost.text = "Press spacebar to speed up";
        }
        else if (ShipMovement.Instance.IsBoosted)
        {
            isRadyToBoost.text = "Acceleration is active";
        }
        else
        {
            isRadyToBoost.text = "Acceleration not available";
        }
        CheckBestScore();

    }

    //Проигрыш
    public void PlayerLoose()
    {
        Time.timeScale = 0;
        CheckBestScore();
    }

    private void CheckBestScore()
    {
        if (PlayerPrefs.GetInt("Score") < points)
        {
            PlayerPrefs.SetInt("Score", points);
            newBest.text = "New best: " + points;
        }
    }
}
