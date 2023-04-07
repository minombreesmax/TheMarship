using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBarrel : Barrel
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            BarrelSound.volume = PlayerPrefs.GetFloat("Volume");
            BarrelSound.Play();
            DataHolder.specialAbility = DataHolder.specialAbility < 5 ? DataHolder.specialAbility += 1 : 5;
            barrel.SetActive(false);
        }
    }

}
