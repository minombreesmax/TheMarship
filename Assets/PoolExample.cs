using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolExample : MonoBehaviour
{
    [SerializeField] private int poolCount = 3;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Cube cubePrefab;

    private PoolMono<Cube> pool;

    private void Start()
    {
        this.pool = new PoolMono<Cube>(this.cubePrefab, this.poolCount, this.transform);
        this.pool.autoExpand = this.autoExpand;
    }

    private void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            this.CreateCube();
        }
    }

    private void CreateCube() 
    {
        var rX = Random.Range(-5f, 5f);
        var rZ = Random.Range(-5f, 5f);
        var Y = 0;

        var rPosition = new Vector3(rX, Y, rZ);
        var cube = this.pool.GetFreeElement();
        cube.transform.position = rPosition;
    }
}
