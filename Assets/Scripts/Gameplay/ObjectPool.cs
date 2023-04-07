using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private const int CRATERS_COUNT = 7;

    public int poolCount;
    public bool autoExpand = false;

    public MarsEntity[] Rocks, Meteors, Craters;
    public MarsEntity FuelBarrel, SpecialBarrel;

    private Pool<MarsEntity> RocksCryLargeAPool, RocksCryLargeBPool, RocksLargeAPool, RocksLargeBPool;
    private Pool<MarsEntity> MeteorsPool, MeteorsDetailedPool, MeteorsHalfPool; 
    private Pool<MarsEntity> BarrelPool, SpecialBarrelPool, CratersPool, CratersLargePool;

    private readonly string[] BasicEntities = { "Rocks", "Meteors", "Barrel" };
    private readonly string[] RocksEntities = { "RocksCryLargeA", "RocksCryLargeB", "RocksLargeA", "RocksLargeB" };
    private readonly string[] MeteorsEntities = { "Meteor", "MeteorDetailed", "MeteorHalf" };
    private readonly string[] BarrelEntities = { "FuelBarrel", "SpecialBarrel" };

    private float spawnRate = 1.5f;

    private void Start()
    {
        PoolsInit();
        StartCoroutine(ObstacleGeneration());
        StartCoroutine(CratersGeneration());
    }

    protected IEnumerator ObstacleGeneration()
    {
        while (true)
        {
            if (spawnRate > 0.5f)
                spawnRate -= (10 * PlayerPrefs.GetFloat("Speed"));

            string entity = BasicEntities[Random.Range(0, BasicEntities.Length)];

            if (entity == "Rocks") 
            {
                entity = RocksEntities[Random.Range(0, BasicEntities.Length)];
                switch (entity) 
                {
                    case "RocksCryLargeA":
                        CreateObject(RocksCryLargeAPool, Random.Range(90f, 120f));
                        break;
                    case "RocksCryLargeB":
                        CreateObject(RocksCryLargeBPool, Random.Range(90f, 120f));
                        break;
                    case "RocksLargeA":
                        CreateObject(RocksLargeAPool, Random.Range(90f, 120f));
                        break;
                    case "RocksLargeB":
                        CreateObject(RocksLargeBPool, Random.Range(90f, 120f));
                        break;
                }
            }

            if (entity == "Meteors") 
            {
                entity = MeteorsEntities[Random.Range(0, MeteorsEntities.Length)];

                switch (entity) 
                {
                    case "Meteor":
                        CreateObject(MeteorsPool, Random.Range(90f, 130f), Random.Range(20f, 23f));
                        break;
                    case "MeteorDetailed":
                        CreateObject(MeteorsDetailedPool, Random.Range(90f, 130f), Random.Range(21f, 23f));
                        break;
                    case "MeteorHalf":
                        CreateObject(MeteorsHalfPool, Random.Range(90f, 130f), Random.Range(19f, 22f));
                        break;
                }
            }

            if (entity == "Barrel")
            {
                entity = BarrelEntities[Random.Range(0, BarrelEntities.Length)];
                CreateObject(entity == "FuelBarrel"? BarrelPool : SpecialBarrelPool, Random.Range(90f, 120f));
            }
           
            yield return new WaitForSeconds(spawnRate);
        }
    }

    protected IEnumerator CratersGeneration() 
    {
        while (true) 
        {
            CreateObject(CratersPool, Random.Range(80f, 120f), 5f, Random.Range(5f, 50f));
            CreateObject(CratersLargePool, Random.Range(80f, 120f), 5f, Random.Range(-5f, -30f));

            yield return new WaitForSeconds(spawnRate/2);
        }
    }

    private void PoolsInit() 
    {
        RocksCryLargeAPool = new Pool<MarsEntity>(Rocks[0], poolCount, transform);
        RocksCryLargeAPool.autoExpand = autoExpand;

        RocksCryLargeBPool = new Pool<MarsEntity>(Rocks[1], poolCount, transform);
        RocksCryLargeBPool.autoExpand = autoExpand;

        RocksLargeAPool = new Pool<MarsEntity>(Rocks[2], poolCount, transform);
        RocksLargeAPool.autoExpand = autoExpand;

        RocksLargeBPool = new Pool<MarsEntity>(Rocks[3], poolCount, transform);
        RocksLargeBPool.autoExpand = autoExpand;

        MeteorsPool = new Pool<MarsEntity>(Meteors[0], poolCount, transform);
        MeteorsPool.autoExpand = autoExpand;

        MeteorsDetailedPool = new Pool<MarsEntity>(Meteors[1], poolCount, transform);
        MeteorsDetailedPool.autoExpand = autoExpand;

        MeteorsHalfPool = new Pool<MarsEntity>(Meteors[2], poolCount, transform);
        MeteorsHalfPool.autoExpand = autoExpand;

        BarrelPool = new Pool<MarsEntity>(FuelBarrel, poolCount, transform);
        BarrelPool.autoExpand = autoExpand;

        SpecialBarrelPool = new Pool<MarsEntity>(SpecialBarrel, poolCount, transform);
        SpecialBarrelPool.autoExpand = autoExpand;

        CratersPool = new Pool<MarsEntity>(Craters[0], CRATERS_COUNT, transform);
        CratersPool.autoExpand = autoExpand;

        CratersLargePool = new Pool<MarsEntity>(Craters[1], CRATERS_COUNT, transform);
        CratersLargePool.autoExpand = autoExpand;

    }

    private void CreateObject(Pool<MarsEntity> pool, float posX, float posY = 5, float posZ = 0)
    {
        var position = new Vector3(posX, posY, posZ);
        var entity = pool.GetFreeElement();
        entity.transform.position = position;
    }
}
