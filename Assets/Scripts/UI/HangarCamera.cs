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
    private int x;

    private void Start()
    {
        CameraInitialize();  
    }

    public void CameraInitialize() 
    {
        transform.position = new Vector3(-70, 40, -80);
        yourScore.text = $"Record: {PlayerPrefs.GetInt("Best")}";
        crystals.text = $"{PlayerPrefs.GetInt("Crystals")}";
        transform.position = new Vector3(GetPositionX(), transform.position.y, transform.position.z);
        StartCoroutine(SetVolume());
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

    private IEnumerator SetVolume() 
    {
        ClickSound.volume = PlayerPrefs.GetFloat("Volume");
        SwitchSound.volume = PlayerPrefs.GetFloat("Volume");
        yield return new WaitForSeconds(1);
    }

    private void CameraMove(float h)
    {
        SwitchSound.Play();
        float x = transform.position.x + h;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private float GetPositionX() 
    {
        switch (PlayerPrefs.GetInt("shipNumber"))
        {
            case 0:
                x = -70;
                break;
            case 1:
                x = -50;
                break;
            case 2:
                x = -30;
                break;
            case 3:
                x = -10;
                break;
            case 4:
                x = 10;
                break;
            case 5:
                x = 30;
                break;
            case 6:
                x = 50;
                break;
        }

        return x;
    }

   
}
