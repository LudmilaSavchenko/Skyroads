using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameCanvasText : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject shipMovement;

    //присваиваем значения показателей
    [SerializeField] private Text score;
    [SerializeField] private Text speed;
    [SerializeField] private Text timer;
    [SerializeField] private Text asteroidCount;
    [SerializeField] private Text speedBoost;
    [SerializeField] private Text bestScore;

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
        if (score != null)
            score.text = GameManager.Instance.Score.ToString();

        if (speed != null)
            speed.text = ShipMovement.Instance.Speed.ToString();

        if (timer != null)
            timer.text = GameManager.Instance.CurrentTime;
        if (asteroidCount != null)
            asteroidCount.text = GameManager.Instance.AsteroidsCount.ToString();

        if (speedBoost != null) // подумать что с бустом делать
            speedBoost.text = GameManager.Instance.BoostMessage;

        if (bestScore != null)
            bestScore.text = GameManager.Instance.BestScore.ToString();
    }
}
