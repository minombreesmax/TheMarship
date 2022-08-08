using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRock : Rock
{
    public GameObject crystal;

    void OnBecameInvisible()
    {
        crystal.SetActive(true);
    }
}
