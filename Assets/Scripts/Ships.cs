using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ships : MonoBehaviour
{
    Rigidbody shipRigidbody;
    float y = 15f, force = 0.5f, x;
    public float shipSpeed;

    void Start()
    {
        shipRigidbody = GetComponent<Rigidbody>();
        DataHolder.up = false;
        DataHolder.down = false;
        DataHolder.fly = false;
        x = shipRigidbody.transform.position.x;
    }

    void SetStartPosition()
    {
        if(x < -30)
        {
            x += 0.3f;
            shipRigidbody.transform.position = new Vector3(x, transform.position.y, transform.position.z );
        }
        else
        {
            DataHolder.fly = true;
            PlayerPrefs.SetFloat("Speed", shipSpeed);
        }
    }

    void Flying()
    {
        float posY = shipRigidbody.transform.position.y;
        
        if(DataHolder.up)
        {
            y = posY < 30? posY + force : 30f;
            DataHolder.up = posY == 30? false : true;
        }
        else if(DataHolder.down)
        {
            y = posY > 5? posY - force : 5f;
            DataHolder.down = posY == 5? false : true;
        }
        else
        {
            if(posY == 15)
            {
                y = posY;
            }

            if(posY < 15)
            {
                y = posY + force;
            }
            
            if(posY > 15)
            {
                y = posY - force;
            }
           
            DataHolder.up = false; DataHolder.down = false;
        }

        shipRigidbody.transform.position = new Vector3(-30, y, 0);
    }

    void FixedUpdate()
    {
        SetStartPosition();
        
        if(DataHolder.fly)
        {
            Flying();
        }
    }
}