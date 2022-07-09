using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public Button PauseButton, ResumeButton;
    public Text Score, Best, newRecord, Crystals;
    public GameObject PauseMenu, GameOverMenu;
    public GameObject[] Ships = new GameObject[8];
    public GameObject[] Rocks = new GameObject[4];
    public GameObject[] Craters = new GameObject[2];
    public GameObject[] Meteors = new GameObject[2];
    float[] PositionX = {70f, 80f, 90f, 100f, 110f, 120f};
    string[] MarsObjects = {"Rock", "Meteor"};
    float score = 0, maxSpeed;
    
    void Start()
    {
        var position = new Vector3(-55f, 15f, 0f);
        Instantiate(Ships[PlayerPrefs.GetInt("shipNumber")], position, Quaternion.Euler(0f, 90f, 0f));
        scoreText.gameObject.SetActive(false);
        DataHolder.gameOver = false;
        maxSpeed = 1f + PlayerPrefs.GetFloat("Speed") * 5000f;
        DataHolder.gameSpeed = 1f;
    }

    void MarsObjectSpawn(GameObject[] MarsObj, float posX, float posY = 5, float posZ = 5)
    {
        if(DataHolder.fly)
        {
            GameObject marsObj = MarsObj[UnityEngine.Random.Range(0, MarsObj.Length)];
            var position = new Vector3(posX, posY, posZ);
            Instantiate(marsObj, position, Quaternion.identity);
        }
    }

    void EnvironmentGeneration() 
    {
        if (Time.time % 2f == 0)
        {
            string marsObj = MarsObjects[Random.Range(0, MarsObjects.Length)];

            if (marsObj == "Rock")
            {
                MarsObjectSpawn(Rocks, PositionX[Random.Range(0, PositionX.Length)]);
            }

            if (marsObj == "Meteor")
            {
                MarsObjectSpawn(Meteors, Random.Range(90f, 130f), Random.Range(15f, 30f));

            }
        }

        if (Time.time % 0.5 == 0)
        {
            MarsObjectSpawn(Craters, Random.Range(80f, 100f), 5f, Random.Range(-20f, 50f));
        }
    }

    public void ShipUp()
    {
        DataHolder.up = true;
    }

    public void ShipDown()
    {
        DataHolder.down = true;
    }

    public void Pause()
    {
        PauseButton.gameObject.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PauseButton.gameObject.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverMenu.SetActive(DataHolder.gameOver); 
        PauseButton.gameObject.SetActive(false); 
        scoreText.gameObject.SetActive(false);

        DataHolder.best = PlayerPrefs.HasKey("Best")? PlayerPrefs.GetInt("Best") : 0;

        if(score > DataHolder.best)
        {
            DataHolder.best = score;
            PlayerPrefs.SetInt("Best", (int)DataHolder.best);
            newRecord.gameObject.SetActive(true);
        }
        else
        {
            newRecord.gameObject.SetActive(false);
        }
    
        Score.text = $"Score: {(int)score}";    
        Best.text = $"Best: {PlayerPrefs.GetInt("Best")}"; 
        Time.timeScale = 0f;
    }

    public void ScoreCount()
    {
        scoreText.text = $"Score: {(int)score}";
        score += DataHolder.gameSpeed/2;
        Crystals.text = $"{PlayerPrefs.GetInt("Crystals")}";
    }

    public void DesktopControl()
    {
        if(Input.GetKey("up"))
        {
            ShipUp();
        }
        else if(Input.GetKey("down"))
        {
            ShipDown();
        }
    }

    void FixedUpdate()
    {
        scoreText.gameObject.SetActive(DataHolder.fly);

        if(DataHolder.fly)
        {
            ScoreCount();
        } 

        if(DataHolder.gameOver)
        {
            GameOver();
        }

        if(DataHolder.gameSpeed < maxSpeed)
        {
            DataHolder.gameSpeed += PlayerPrefs.GetFloat("Speed");
        }

        EnvironmentGeneration();
        
        DesktopControl();
    }
}
