using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game : MonoBehaviour
{
    const float MAX_SPEED = 2f, FUEL = 30f;
    public GameObject[] Ships = new GameObject[7];
    public GameObject GameOverMenu, Fuelmetr;
    public Button PauseButton;
    public Text scoreText, scoreGameOver, Best, newRecord, Crystals;
    private float score;
    private int shipNumber;

    private void Awake()
    {
        GlobalEventManager.GameOverAction.AddListener(GameOver);
    }

    private void Start()
    {
        GameStart();
    }

    public void GameOver()
    {
        if(PlayerPrefs.GetInt("Vibration") == 1)
            Handheld.Vibrate();

        GameOverMenu.SetActive(true);
        PauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        Fuelmetr.gameObject.SetActive(false);

        DataHolder.best = PlayerPrefs.HasKey("Best") ? PlayerPrefs.GetInt("Best") : 0;

        if (score > DataHolder.best)
        {
            DataHolder.best = score;
            PlayerPrefs.SetInt("Best", (int)DataHolder.best);
            newRecord.gameObject.SetActive(true);
        }
        else
        {
            newRecord.gameObject.SetActive(false);
        }

        scoreGameOver.text = $"Score: {(int)score}";
        Best.text = $"Best: {PlayerPrefs.GetInt("Best")}";
        Time.timeScale = 0f;
    }

    public void ScoreCount()
    {
        scoreText.text = $"Score: {(int)score}";
        score += PlayerPrefs.GetFloat("Points");
        Crystals.text = $"{PlayerPrefs.GetInt("Crystals")}";
    }

    protected void GameStart()
    {
        var position = new Vector3(-55f, 15f, 0f);
        shipNumber = PlayerPrefs.GetInt("shipNumber");
        Instantiate(Ships[shipNumber], position, Quaternion.Euler(0f, 90f, 0f));
        scoreText.gameObject.SetActive(false);
        DataHolder.fuel = FUEL;
        DataHolder.gameSpeed = 1f;
    }

    protected void GameProcess()
    {
        scoreText.gameObject.SetActive(DataHolder.fly);

        if (DataHolder.fly)
        {
            ScoreCount();
        }

        if (DataHolder.gameSpeed < MAX_SPEED)
        {
            DataHolder.gameSpeed += PlayerPrefs.GetFloat("Speed");
        }
    }

    private void FixedUpdate()
    {
        GameProcess();
    }
}
