using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MarsEntity
{
    private void Behavior()
    {
        Motion();
        rotationZ++;
        Rigidbody.transform.position = new Vector3(x, y, 0);
        Rigidbody.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        AutoDestroy();
    }

    private void FixedUpdate()
    {
        Behavior();
    }

}
