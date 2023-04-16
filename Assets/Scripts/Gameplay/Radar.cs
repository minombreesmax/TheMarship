using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private const int RAYS_COUNT = 5;
    private RaycastHit hit;
    private Ray[] Rays = new Ray[RAYS_COUNT];
    private Vector3[] RaysPosition = new Vector3[RAYS_COUNT];
    private GameObject[] RadarRays = new GameObject[RAYS_COUNT];
    private float y;


    private void OnEnable()
    {
        CreateRays();
        StartCoroutine(ShipRadar());
    }

    private void CreateRays()
    {
        var Radar = gameObject.transform.GetChild(0).gameObject;
        Radar.SetActive(true);
        y = 18;

        for (int i = 0; i < RAYS_COUNT; i++)
        {
            RaysPosition[i] = new Vector3(-30, y, transform.position.z);
            Rays[i] = new Ray(RaysPosition[i], transform.forward);
            y -= 3f;

            RadarRays[i] = Radar.transform.GetChild(i).gameObject;
            RadarRays[i].SetActive(false);
        }
    }

    private void DrawRays() 
    {
        for (int i = 0; i < RAYS_COUNT; i++)
            Debug.DrawRay(RaysPosition[i], transform.forward * 70, Color.green);
    }

    private IEnumerator ShipRadar() 
    {
        while (true) 
        {
            DrawRays();

            for (int i = 0; i < RAYS_COUNT; i++) 
            {
                if (Physics.Raycast(Rays[i], out hit))
                {
                    RadarRays[i].SetActive(hit.distance > 70 ? true : false);
                }
            }

            if (enabled == false)
                break;

            yield return null;
        }
    }
}
