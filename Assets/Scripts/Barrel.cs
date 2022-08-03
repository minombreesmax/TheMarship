using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : Rocks
{
    public GameObject barrel;
    public AudioSource BarrelSound;

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            BarrelSound.Play();
            DataHolder.fuel = DataHolder.fuel < 25? DataHolder.fuel += 5 : 30;
            barrel.SetActive(false);
        }
    }
}
