using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsEntity : MonoBehaviour
{
    public float lifetime;
    protected Rigidbody Rigidbody;
    protected float x, y, z, rotationZ;

    protected void Start()
    {
        GetMarsEntityData();
    }

    private void OnEnable()
    {
        StartCoroutine(LifeRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(LifeRoutine());
    }

    private IEnumerator LifeRoutine() 
    {
        yield return new WaitForSeconds(this.lifetime);
        Deactivate();
    }

    protected void GetMarsEntityData()
    {
        Rigidbody = GetComponent<Rigidbody>();
        x = Rigidbody.transform.position.x;
        y = Rigidbody.transform.position.y;
        z = Rigidbody.transform.position.z;
        rotationZ = Rigidbody.transform.rotation.z;
    }

    protected void Motion() 
    {
        x = transform.position.x - DataHolder.gameSpeed;
    }

    private void Deactivate() 
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            GlobalEventManager.GameOver();
        }
    }
}
