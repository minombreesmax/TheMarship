using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MarsEntity
{
    private void Behavior()
    {
        Motion();
        rotationZ++;
        Rigidbody.transform.SetPositionAndRotation(new Vector3(x, y, 0), Quaternion.Euler(0, 0, rotationZ));
    }

    private void FixedUpdate()
    {
        Behavior();
    }

}
