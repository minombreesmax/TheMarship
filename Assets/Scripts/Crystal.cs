using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void Start()
    {
        DataHolder.crystals = PlayerPrefs.GetInt("Crystals");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ship")
        {
            gameObject.SetActive(false);
            DataHolder.crystals++;
            PlayerPrefs.SetInt("Crystals", DataHolder.crystals);
        }
    }
}
