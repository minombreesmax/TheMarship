using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MarsEntity
{
    private void Behavior()
    {
        Motion();
        Rigidbody.transform.position = new Vector3(x, 5f, z);
    }

    private void FixedUpdate()
    {
        Behavior();
    }

}
