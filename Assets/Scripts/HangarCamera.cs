using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarCamera : MonoBehaviour
{
    public GameObject MissCrystalsMenu;
    public Text yourScore, crystals;
    public AudioSource ClickSound, SwitchSound;

    private void Start()
    {
        CameraInitialize();  
    }

    public void CameraInitialize() 
    {
        transform.position = new Vector3(-70, 40, -80);
        yourScore.text = $"Record: {PlayerPrefs.GetInt("Best")}";
        crystals.text = $"{PlayerPrefs.GetInt("Crystals")}";
    }

    public void CameraLeft()
    {
        if(transform.position.x > -70)
        {
            CameraMove(-20);
        }

        MissCrystalsMenu.SetActive(false);
    }

    public void CameraRight()
    {
        if(transform.position.x < 50)
        {
            CameraMove(20);
        }

        MissCrystalsMenu.SetActive(false);
    }

    public void BackToMainMenu() 
    {
        ClickSound.Play();
        SceneManager.LoadScene(0);
    }

    private void CameraMove(float h)
    {
        SwitchSound.Play();
        float x = transform.position.x + h;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

}
