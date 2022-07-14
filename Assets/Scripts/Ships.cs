using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ships : MonoBehaviour
{
    public Animator animator;
    public float shipSpeed;
    float animationSpeed;

    void Start() 
    {
        animator.Play("SetStartPosition");
        DataHolder.fly = true;
        PlayerPrefs.SetFloat("Speed", shipSpeed);
    }

    void Fly() 
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
    }

    void FixedUpdate()
    {
        Fly();

        animationSpeed = animator.speed + (shipSpeed / 2);
        animator.speed = animationSpeed;
    }
}