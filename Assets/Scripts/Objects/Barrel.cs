using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MarsEntity
{
    public GameObject barrel;
    public AudioSource BarrelSound;

    void OnBecameInvisible()
    {
        barrel.SetActive(true);
    }

    private void Behavior()
    {
        Motion();
        Rigidbody.transform.position = new Vector3(x, 5f, z);
    }

    private void FixedUpdate()
    {
        Behavior();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            BarrelSound.volume = PlayerPrefs.GetFloat("Volume");
            BarrelSound.Play();
            DataHolder.fuel = DataHolder.fuel < 20? DataHolder.fuel += 10 : 30;
            barrel.SetActive(false);
        }
    }
}
