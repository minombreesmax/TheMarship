using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    const float MAX_SPEED = 3f;
    public Button PauseButton, ResumeButton;
    public Text scoreText, Score, Best, newRecord, Crystals;
    public GameObject PauseMenu, GameOverMenu;
    public GameObject[] Ships = new GameObject[7];
    public GameObject[] Rocks = new GameObject[4];
    public GameObject[] Craters = new GameObject[2];
    public GameObject[] Meteors = new GameObject[2];
    private string[] MarsObjects = {"Rock", "Meteor"};
    private float score, spawnRate = 1.5f;
   
    private void Start()
    {
        GameStart();
        StartCoroutine(ObstacleGeneration());
        StartCoroutine(CratersGeneration());   
    }

    #region Coroutines
 
    private IEnumerator ObstacleGeneration() 
    {
        while (true) 
        {
            if (spawnRate > 0.5f)
                spawnRate -= (5 * PlayerPrefs.GetFloat("Speed"));

            yield return new WaitForSeconds(spawnRate);
            string marsObj = MarsObjects[Random.Range(0, MarsObjects.Length)];

            if (marsObj == "Rock")
            {
                MarsObjectSpawn(Rocks, Random.Range(90f, 120f));
            }

            if (marsObj == "Meteor")
            {
                MarsObjectSpawn(Meteors, Random.Range(90f, 130f), Random.Range(22f, 25f));
            }
        }
    }

    private IEnumerator CratersGeneration() 
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate/3);
            MarsObjectSpawn(Craters, Random.Range(80f, 100f), 5f, Random.Range(-20f, 50f));
        }
    }
    
    #endregion

    #region UI
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

    #endregion

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
        score += PlayerPrefs.GetFloat("Points");
        Crystals.text = $"{PlayerPrefs.GetInt("Crystals")}";
    }

    private void MarsObjectSpawn(GameObject[] MarsObj, float posX, float posY = 5, float posZ = 0)
    {
        if (DataHolder.fly)
        {
            GameObject marsObj = MarsObj[Random.Range(0, MarsObj.Length)];
            var position = new Vector3(posX, posY, posZ);
            Instantiate(marsObj, position, Quaternion.identity);
        }
    }

    private void DesktopControl()
    {
        if(Input.GetKey("up"))
        {
            ShipUp();
        }
        
        if(Input.GetKey("down"))
        {
            ShipDown();
        }
    }

    private void GameStart()
    {
        var position = new Vector3(-55f, 15f, 0f);
        Instantiate(Ships[PlayerPrefs.GetInt("shipNumber")], position, Quaternion.Euler(0f, 90f, 0f));
        scoreText.gameObject.SetActive(false);
        DataHolder.gameOver = false;
        DataHolder.gameSpeed = 1f;
    }

    private void GameProcess()
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

        DesktopControl();
    }

    void FixedUpdate()
    {
        GameProcess();
    }
}
