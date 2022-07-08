using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HangarCamera : MonoBehaviour
{
    public GameObject checkmark;
    public Text yourScore, crystals;

    void Start()
    {
        transform.position = new Vector3(-70, 40, -80);
        yourScore.text = $"Record: {PlayerPrefs.GetInt("Best")}";
        crystals.text = $"{PlayerPrefs.GetInt("Crystals")}";
    }

    void CameraMove(float h)
    {
        float x = transform.position.x + h;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void CameraLeft()
    {
        if(transform.position.x > -70)
        {
            CameraMove(-20);
        }
    }

    public void CameraRight()
    {
        if(transform.position.x < 70)
        {
            CameraMove(20);
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
