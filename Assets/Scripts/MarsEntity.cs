using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MarsEntity : MonoBehaviour
{
    protected Rigidbody Rigidbody;
    protected float x, y, z, rotationZ;

    protected void Start()
    {
        GetMarsEntityData();
    }

    protected void GetMarsEntityData()
    {
        Rigidbody = GetComponent<Rigidbody>();
        x = Rigidbody.transform.position.x;
        y = Rigidbody.transform.position.y;
        z = Rigidbody.transform.position.z;
        rotationZ = Rigidbody.transform.rotation.z;
    }

    protected void AutoDestroy() 
    {
        if (Rigidbody.transform.position.x == -115f)
        {
            Destroy(gameObject);
        }
    }

    protected void Motion() 
    {
        x = x > -110f ? x -= DataHolder.gameSpeed : -115f;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            DataHolder.gameOver = true;
        }
    }
}
