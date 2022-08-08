using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCrystalsMenu : MonoBehaviour
{
    private AudioSource ErrorSound;

    private void Start()
    {
        ErrorSound = GetComponent<AudioSource>();
        ErrorSound.volume = PlayerPrefs.GetFloat("Volume");
        ErrorSound.Play();
    }

    public void SetMenuOff()
    {
        gameObject.SetActive(false);
    }

}
