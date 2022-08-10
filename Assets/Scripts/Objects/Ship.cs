using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    public Animator animator;
    public float Speed, Points;
    private float shipSpeed, flowrate = 0.02f;

    private void Start()
    {
        ShipStart();
    }

    private IEnumerator Control()
    {
        yield return new WaitForSeconds(1);
        GlobalEventManager.ShipUpAction.AddListener(ShipUp);
        GlobalEventManager.ShipDownAction.AddListener(ShipDown);
    }

    private void ShipStart()
    {
        animator.Play("SetStartPosition");
        DataHolder.fly = true;
        shipSpeed = Speed / 100000;

        PlayerPrefs.SetFloat("Speed", shipSpeed);
        PlayerPrefs.SetFloat("Points", Points);

        StartCoroutine(Control());
    }

    private void ShipUp() 
    {
        animator.Play("FlyUp");
    }

    private void ShipDown() 
    {
        animator.Play("FlyDown");
    }

    private void Fly()
    {
        DataHolder.fuel -= flowrate;
        animator.speed += (shipSpeed / 2);
    }

    private void FixedUpdate()
    {
        Fly();
    }
}