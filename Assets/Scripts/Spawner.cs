using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] items;
    public GameObject[] props;
    public GameObject enemyPrefab;
    public int maxItems;
    public int maxEnemies;

    [Header("Spawn Points")]
    public Transform enemyParent;
    public Transform itemParent;
    public Transform propParent;
    public Collider[] colliders;
    public float radius;

    private void Start()
    {
        SpawnItems();
        for (int i = 0; i < maxItems; i++)
        {
            SpawnProps();
        }   
        for (int j = 0; j < maxEnemies; j++)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        int maxAttempt = 0;
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;
        while (!canSpawnHere)
        {
            spawnPos = SetPosition();
            canSpawnHere = PreventOverlapSpawn(spawnPos);

            if (canSpawnHere)
            {
                break;
            }

            maxAttempt++;

            if (maxAttempt > 50)
            {
                Debug.Log("MaxAttempt reached");
                spawnPos = new Vector3(0, -1000, 0);
                break;
            }
        }
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        enemy.transform.SetParent(enemyParent);
    }

    private void SpawnItems()
    {

    }

    private void SpawnProps()
    {
        int maxAttempt = 0;
        Vector3 spawnPos = new Vector3(0, 0 , 0);
        bool canSpawnHere = false;
        while(!canSpawnHere)
        {
            spawnPos = SetPosition();
            canSpawnHere = PreventOverlapSpawn(spawnPos);

            if (canSpawnHere)
            {
                break;
            }

            maxAttempt++;

            if (maxAttempt > 50)
            {
                Debug.Log("MaxAttempt reached");
                spawnPos = new Vector3(0, -1000, 0); 
                break;
            }
        }
        GameObject prop = Instantiate(props[Random.Range(0, props.Length)], spawnPos, Quaternion.identity);
        prop.transform.SetParent(propParent);
    }

    private bool PreventOverlapSpawn(Vector3 spawnPos)
    {
        colliders = Physics.OverlapSphere(spawnPos, radius);
        
        
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.tag == "IgnoreCollision")
            {
                continue;
            }
            else if (colliders[i].gameObject.tag != "IgnoreCollision")
            {
                Vector3 center = colliders[i].bounds.center;
                float widthx = colliders[i].bounds.extents.x;
                float widthz = colliders[i].bounds.extents.z;

                float leftExtent = center.x - widthx;
                float rightExtent = center.x + widthx;
                float lowerExtent = center.z - widthz;
                float upperExtent = center.z + widthz;

                if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
                {
                    if (spawnPos.z >= lowerExtent && spawnPos.z <= upperExtent)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private Vector3 SetPosition()
    {
        float randX = Random.Range(12, 350);
        float randZ = Random.Range(-200, 200);
        Vector3 spawnPos = new Vector3(randX, 0.25f, randZ);
        return spawnPos;
    }
}
