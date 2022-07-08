using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsObjects : MonoBehaviour
{
    Rigidbody marsObjectRigidbody;
    float x, y, z, rotationZ;

    void Start()
    {
        marsObjectRigidbody = GetComponent<Rigidbody>();
        x = marsObjectRigidbody.transform.position.x;
        y = marsObjectRigidbody.transform.position.y;
        z = marsObjectRigidbody.transform.position.z;
        rotationZ = marsObjectRigidbody.transform.rotation.z;
    }

    void FixedUpdate()
    {
        x = x > -110f? x -= DataHolder.gameSpeed : -115f;

        if(gameObject.tag == "Meteor")
        {
            rotationZ++;
            marsObjectRigidbody.transform.position = new Vector3(x, y, 0);
            marsObjectRigidbody.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }

        if(gameObject.tag == "Rock" || gameObject.tag == "Crater")
        {
            marsObjectRigidbody.transform.position = new Vector3(x, 5f, z);
        }

        if(marsObjectRigidbody.transform.position.x == -115f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ship")
        {
            DataHolder.gameOver = true;
        }
    }
}