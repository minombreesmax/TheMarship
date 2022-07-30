using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private const float SPEED = 4f;
    public int direction;
    public float target;
    private float tempY;
    private float startY;

    void Start()
    {
        tempY = transform.position.y;
        startY = tempY;
    }

    private void ArrowMoving(float target)
    {
        target += startY;

        if (direction > 0)
            tempY = tempY < target ? tempY + SPEED : startY - 100;

        if (direction < 0)
            tempY = tempY > target ? tempY - SPEED : startY + 100;

        transform.position = new Vector2(transform.position.x, tempY);
    }

    void FixedUpdate()
    {
        ArrowMoving(target);
    }
}
