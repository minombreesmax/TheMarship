using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsEntity : MonoBehaviour
{
    private Rigidbody marsEntityRigidbody;
    private float x, y, z, rotationZ;

    private void Start()
    {
        GetMarsEntityData();
    }

    private void GetMarsEntityData()
    {
        marsEntityRigidbody = GetComponent<Rigidbody>();
        x = marsEntityRigidbody.transform.position.x;
        y = marsEntityRigidbody.transform.position.y;
        z = marsEntityRigidbody.transform.position.z;
        rotationZ = marsEntityRigidbody.transform.rotation.z;
    }

    private void MarsObjectBehavior()
    {
        x = x > -110f ? x -= DataHolder.gameSpeed : -115f;

        if (gameObject.tag == "Meteor")
        {
            rotationZ++;
            marsEntityRigidbody.transform.position = new Vector3(x, y, 0);
            marsEntityRigidbody.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }

        if (gameObject.tag == "Rock" || gameObject.tag == "Crater")
        {
            marsEntityRigidbody.transform.position = new Vector3(x, 5f, z);
        }

        if (marsEntityRigidbody.transform.position.x == -115f)
        {
            Destroy(gameObject);
        }
    }   

    private void FixedUpdate()
    {
        MarsObjectBehavior();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ship")
        {
            DataHolder.gameOver = true;
        }
    }
}
