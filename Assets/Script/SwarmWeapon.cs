using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmWeapon : MonoBehaviour
{

    [Header("Initialization")]
    public EnemyBehavior spawnType;
    public Transform spawnPoint;

    [Space]
    public float initialDelay;
    public float spawnRate;
    public float nextSpawnInterval;
    public int numberOfSpawn;

    float spawnCounter;

    private void Start()
    {
        spawnCounter = Time.time + initialDelay;
    }

    void Update()
    {
        if (Time.time > spawnCounter)
        {
            StartCoroutine("SpawnController");
            spawnCounter = Time.time + spawnRate;
        }
    }

    void Spawn()
    {
        Instantiate(spawnType, spawnPoint.position, Quaternion.identity);
    }

    IEnumerator SpawnController()
    {
        for (int i = 0; i < numberOfSpawn; i++)
        {
            Spawn();

            yield return new WaitForSeconds(nextSpawnInterval);
        }
        
    }
}
