using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public Button PauseButton; 
    public GameObject PauseMenu, Fuelmetr, SpecialAbility;
    public AudioSource ClickSound;

    private void Start()
    {
        StartCoroutine(SetVolume());
    }

    private IEnumerator SetVolume() 
    {
        while (true)
        {
            ClickSound.volume = PlayerPrefs.GetFloat("Volume");
            yield return new WaitForSeconds(1);
        }
    }

    public void Up()
    {
        GlobalEventManager.ShipUp();
    }

    public void Down()
    {
        GlobalEventManager.ShipDown();
    }

    public void Pause(bool status)
    {
        ClickSound.Play();
        PauseButton.gameObject.SetActive(!status);
        PauseMenu.SetActive(status);
        Fuelmetr.SetActive(!status);
        SpecialAbility.SetActive(!status);
        Time.timeScale = status ? 0f : 1f;
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

}
