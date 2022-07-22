using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public void TutorialHide() 
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetString("Tutorial", "OFF");
        SceneManager.LoadScene(1);
    }
}
