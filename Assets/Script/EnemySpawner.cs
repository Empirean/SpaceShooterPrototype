using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float screenHeight;
    float screenWidth;

    public float spawnPad = 1;
    public Behavior enemy;

    public int waveCount;
    public float waveDelay;

    public List<int> spawnCount;
    public List<float> spawnDelay;
    public List<Old_EnemyMovement.Directions> spawnDirection;

    void Start()
    {
        screenHeight = Utility.screenHeight + spawnPad;
        screenWidth = Utility.screenWidth + spawnPad;

        StartCoroutine("SpawnWave");
    }

    IEnumerator SpawnWave()
    {
        Vector3 spawnPoint;

        for (int i = 0; i < waveCount; i++)
        {
            for (int j = 0; j < spawnCount[i]; j++)
            {
                
                spawnPoint = GetSpawnPoint(spawnDirection[i]);

                Spawn(spawnPoint, spawnDirection[i]);

                yield return new WaitForSeconds(spawnDelay[i]);
            }

            yield return new WaitForSeconds(waveDelay);
        }

        
    }

    public void Spawn(Vector3 spawnPoint, Old_EnemyMovement.Directions direction)
    {
        enemy = Instantiate(enemy, spawnPoint, Quaternion.identity) as Behavior;
    }

    private Vector3 GetSpawnPoint(Old_EnemyMovement.Directions direction)
    {
        Vector3 v;

        switch (direction)
        {
            case Old_EnemyMovement.Directions.up:
                v = new Vector3(Random.Range(-Utility.screenWidth,  Utility.screenWidth), -screenHeight, 0);
                break;
            case Old_EnemyMovement.Directions.down:
                v = new Vector3(Random.Range(-Utility.screenWidth,  Utility.screenWidth), screenHeight, 0);
                break;
            case Old_EnemyMovement.Directions.left:
                v = new Vector3(screenWidth, Random.Range( -Utility.screenHeight, Utility.screenHeight),  0);
                break;
            case Old_EnemyMovement.Directions.right:
                v = new Vector3(-screenWidth, Random.Range( -Utility.screenHeight, Utility.screenHeight),  0);
                break;
            default:
                v = Vector3.zero;
                break;
        }

        return v;
    }
}
