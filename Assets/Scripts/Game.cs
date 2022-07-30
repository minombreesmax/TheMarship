using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MarsObjects
{
    const float MAX_SPEED = 2f;
    public GameObject[] Ships = new GameObject[7];
    public GameObject GameOverMenu;
    public Button PauseButton;
    public Text scoreText, scoreGameOver, Best, newRecord, Crystals;
    private float score;

    public void GameOver()
    {
        GameOverMenu.SetActive(DataHolder.gameOver);
        PauseButton.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);

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
        Instantiate(Ships[PlayerPrefs.GetInt("shipNumber")], position, Quaternion.Euler(0f, 90f, 0f));
        scoreText.gameObject.SetActive(false);
        DataHolder.gameOver = false;
        DataHolder.gameSpeed = 1f;
    }

    protected void GameProcess()
    {
        scoreText.gameObject.SetActive(DataHolder.fly);

        if (DataHolder.fly)
        {
            ScoreCount();
        }

        if (DataHolder.gameOver)
        {
            GameOver();
        }

        if (DataHolder.gameSpeed < MAX_SPEED)
        {
            DataHolder.gameSpeed += PlayerPrefs.GetFloat("Speed");
        }
    }

}
