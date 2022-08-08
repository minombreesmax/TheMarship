using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public Button PauseButton; 
    public GameObject PauseMenu, Fuelmetr;
    public AudioSource ClickSound;

    private void Start()
    {
        ClickSound.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void Up()
    {
        DataHolder.up = true;
    }

    public void Down()
    {
        DataHolder.down = true;
    }

    public void Pause()
    {
        ClickSound.Play();
        PauseButton.gameObject.SetActive(false);
        PauseMenu.SetActive(true);
        Fuelmetr.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        ClickSound.Play();
        PauseButton.gameObject.SetActive(true);
        PauseMenu.SetActive(false);
        Fuelmetr.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        ClickSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        ClickSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void DesktopControl()
    {
        if (Input.GetKey("up"))
        {
            Up();
        }

        if (Input.GetKey("down"))
        {
            Down();
        }
    }

    public void FixedUpdate()
    {
        DesktopControl();
        ClickSound.volume = PlayerPrefs.GetFloat("Volume");
    }
}
