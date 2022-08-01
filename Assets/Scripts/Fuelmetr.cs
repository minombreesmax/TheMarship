using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuelmetr : MonoBehaviour
{
    const int MIN_ANGLE = -90, MAX_ANGLE = 90;
    private Transform ArrowTransform;
    private float rotationZ;

    private void Start()
    {
        ArrowTransform = transform.Find("FuelArrow");
        ArrowTransform.eulerAngles = new Vector3(0, 0, -90);
    }

    private void FuelConsumplion() 
    {
        rotationZ = -6 * DataHolder.fuel + 90;
        Mathf.Clamp(rotationZ, MIN_ANGLE, MAX_ANGLE);
        ArrowTransform.eulerAngles = new Vector3(0, 0, rotationZ);
    }

    private void FixedUpdate()
    {
        if(DataHolder.fuel < 0) 
        {
            DataHolder.gameOver = true;
        }

        FuelConsumplion();
    }
}
