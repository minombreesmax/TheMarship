using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ships : MonoBehaviour
{
    public Animator animator;
    public float Speed, Points;
    private float shipSpeed, flowrate = 0.02f;

    private void Start()
    {
        ShipStart();
    }

    private void ShipStart()
    {
        animator.Play("SetStartPosition");

        DataHolder.fly = true;

        shipSpeed = Speed / 100000;

        PlayerPrefs.SetFloat("Speed", shipSpeed);
        PlayerPrefs.SetFloat("Points", Points);
    }

    private void Fly()
    {
        if (DataHolder.up)
        {
            animator.Play("FlyUp");
            DataHolder.up = false;
        }

        if (DataHolder.down)
        {
            animator.Play("FlyDown");
            DataHolder.down = false;
        }

        DataHolder.fuel -= flowrate;
        animator.speed += (shipSpeed / 2);
    }

    private void FixedUpdate()
    {
        Fly();
    }
}