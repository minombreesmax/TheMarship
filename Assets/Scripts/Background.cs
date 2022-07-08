using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float x;

    void Start()
    {
       x = transform.position.x;
    }

    void FixedUpdate()
    {
        x = x > -200? x -= (DataHolder.gameSpeed*0.75f) : 310;
        transform.position = new Vector3(x, 0, 105);
    }
}
