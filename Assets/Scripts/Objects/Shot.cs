using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    private Rigidbody shotRigidbody;
    private float posX, posY, posZ;

    private void Start()
    {
        shotRigidbody = GetComponent<Rigidbody>();
        posX = shotRigidbody.position.x;
        posY = shotRigidbody.position.y;
        posZ = shotRigidbody.position.z;
        StartCoroutine(ShotFlight());
    }

    private IEnumerator ShotFlight() 
    {
        while (true) 
        {
            shotRigidbody.position = new Vector3(posX++, posY, posZ);
            yield return null;
        }
    }

    private IEnumerator ShotEnable()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Meteor") 
        {
            collision.gameObject.SetActive(false);
        }

        Destroy(this.gameObject);
    }

}
