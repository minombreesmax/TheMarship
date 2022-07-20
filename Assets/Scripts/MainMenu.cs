using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsMenu;
    public GameObject HangarButton, SettingsButton;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsOpen()
    {
        SettingsMenu.SetActive(true);
        HangarButton.SetActive(false);
        SettingsButton.SetActive(false);
    }

    public void SettingsClose()
    {
        SettingsMenu.SetActive(false);
        HangarButton.SetActive(true);
        SettingsButton.SetActive(true);
    }

    public void HangarOpen()
    {
        SceneManager.LoadScene(2);
    }
}