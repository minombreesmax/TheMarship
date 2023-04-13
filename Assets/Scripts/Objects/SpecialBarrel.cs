using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBarrel : Barrel
{
    protected override void OnCollisionEnter(Collision collision)
    {
        var tag = collision.gameObject.tag;

        if (tag == "Ship" || tag == "Shield")
        {
            BarrelSound.volume = PlayerPrefs.GetFloat("Volume");
            BarrelSound.Play();
            DataHolder.specialAbility = DataHolder.specialAbility < 5 ? DataHolder.specialAbility += 1 : 5;
            barrel.SetActive(false);
        }
    }

}
