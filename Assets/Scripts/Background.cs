using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float x;

    private void Start()
    {
       x = transform.position.x;
    }

    private void FixedUpdate()
    {
        x = x > -240? x -= (DataHolder.gameSpeed/2) : 260;
        transform.position = new Vector3(x, 0, 105);
    }
}
