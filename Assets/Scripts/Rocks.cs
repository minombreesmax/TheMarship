using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MarsEntity
{
    private void Behavior()
    {
        Motion();
        Rigidbody.transform.position = new Vector3(x, 5f, z);
        AutoDestroy();
    }

    private void FixedUpdate()
    {
        Behavior();
    }

}
