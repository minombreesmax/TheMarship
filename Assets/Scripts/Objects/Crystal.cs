using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public AudioSource CrystalSound;

    private void Start()
    {
        DataHolder.crystals = PlayerPrefs.GetInt("Crystals");
        CrystalSound.volume = PlayerPrefs.GetFloat("Volume");
    }

    private void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.tag;

        if (tag == "Ship" || tag == "Shield")
        {
            CrystalSound.Play();
            gameObject.SetActive(false);
            DataHolder.crystals++;
            PlayerPrefs.SetInt("Crystals", DataHolder.crystals);
        }
    }
}
