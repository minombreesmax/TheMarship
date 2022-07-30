using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsObjects : MonoBehaviour
{
    public GameObject[] Rocks = new GameObject[4];
    public GameObject[] Craters = new GameObject[2];
    public GameObject[] Meteors = new GameObject[3];

    private float spawnRate = 1.5f;
    private string[] Entities = {"Rock", "Meteor"};
    
    protected IEnumerator ObstacleGeneration()
    {
        while (true)
        {
            if (spawnRate > 0.5f)
                spawnRate -= (5 * PlayerPrefs.GetFloat("Speed"));

            yield return new WaitForSeconds(spawnRate);
            string marsObj = Entities[Random.Range(0, Entities.Length)];

            if (marsObj == "Rock")
            {
                MarsObjectSpawn(Rocks, Random.Range(90f, 120f));
            }

            if (marsObj == "Meteor")
            {
                MarsObjectSpawn(Meteors, Random.Range(90f, 130f), Random.Range(22f, 25f));
            }
        }
    }

    protected IEnumerator CratersGeneration()
    {
        while (true)
        {
            MarsObjectSpawn(Craters, Random.Range(80f, 100f), 5f, Random.Range(-20f, 50f));
            yield return new WaitForSeconds(spawnRate / 3);
        }
    }

    private void MarsObjectSpawn(GameObject[] MarsObj, float posX, float posY = 5, float posZ = 0)
    {
        if (DataHolder.fly)
        {
            GameObject marsObj = MarsObj[Random.Range(0, MarsObj.Length)];
            var position = new Vector3(posX, posY, posZ);
            Instantiate(marsObj,position,Quaternion.identity);
        }
    }

}