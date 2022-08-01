using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button PauseButton; 
    public GameObject PauseMenu;
    public AudioSource ClickSound;
 
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
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        ClickSound.Play();
        PauseButton.gameObject.SetActive(true);
        PauseMenu.SetActive(false);
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
    }
}
