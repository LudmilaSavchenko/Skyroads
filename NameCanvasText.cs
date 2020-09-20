using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameCanvasText : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ShipMovement shipMovement;

    //присваиваем значения показателей
    [SerializeField] private Text score;
    [SerializeField] private Text speed;
    [SerializeField] private Text timer;
    [SerializeField] private Text asteroidCount;
    [SerializeField] private Text speedBoost;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text newBestScore;

    void Start()
    {

        //Выводим поля
        //timer.text = "Time: " + (seconds / 60) + ":" + (seconds % 60);
        //score.text = " 0";
        //speed.text = "Speed: " + ShipMovement.Instance.Speed;
        //asteroidCount.text = "0";
        //speedBoost.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (score != null && gameManager!=null)
            score.text = gameManager.Score.ToString();

        if (speed != null && shipMovement != null)
            speed.text = shipMovement.Speed.ToString();

        if (timer != null && gameManager != null)
            timer.text = gameManager.CurrentTime;

        if (asteroidCount != null && gameManager != null)
            asteroidCount.text = gameManager.AsteroidsCount.ToString();

        if (speedBoost != null && gameManager != null) // подумать что с бустом делать
            speedBoost.text = gameManager.BoostMessage;

        if (bestScore != null)
            bestScore.text = PlayerPrefs.GetInt("Score").ToString(); //gameManager.BestScore.ToString();

        if (newBestScore != null && gameManager != null && gameManager.NewBestScore == true)
            newBestScore.text = "New best score!";
    }
}
