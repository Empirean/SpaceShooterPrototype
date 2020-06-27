﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerMaster : MonoBehaviour
{
    public event Action OnPlayerWin;
    public event Action OnLevelShow;
    public event Action OnLevelHide;

    [Header("Enemy Prefabs")]
    public Unit berserkerType;
    public Unit chaserType;
    public Unit pulserType;
    public Unit trailerType;

    [Space]
    public float nextWaveDelay = 1.5f;
    public int waveCount;


    [Space]
    [Header("Enemy Count")]
    public int[] firstLayerCount;
    public int[] secondLayerCount;
    public int[] thirdLayerCount;

    public enum EnemyTypes
    {
        berserker,
        chaser,
        pulser,
        trailer
    }

    [Space]
    [Header("Enemy Layers")]
    public EnemyTypes[] firstLayerEnemy;
    public EnemyTypes[] secondLayerEnemy;
    public EnemyTypes[] thirdLayerEnemy;

    int currentWave;


    private void Start()
    {
        StartCoroutine("SpawnSequence");
    }

    IEnumerator SpawnSequence()
    {
        if (OnLevelShow != null)
        {
            OnLevelShow();
        }

        yield return new WaitForSeconds(3);

        if (OnLevelShow != null)
        {
            OnLevelHide();
        }

        yield return new WaitForSeconds(1);

        for (currentWave = 0; currentWave < waveCount; currentWave++)
        {
            yield return StartCoroutine("SpawnCurrentWave");
        }

        if (OnPlayerWin != null)
        {
            OnPlayerWin();
        }
    }

    IEnumerator SpawnCurrentWave()
    {
        for (int i = 0; i < firstLayerCount[currentWave]; i++)
        {
            switch (firstLayerEnemy[currentWave])
            {
                case EnemyTypes.berserker:
                    SpawnBerserker();
                    break;
                case EnemyTypes.chaser:
                    SpawnChaser();
                    break;
                case EnemyTypes.pulser:
                    SpawnPulser();
                    break;
                case EnemyTypes.trailer:
                    SpawnTrailer();
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1);
        }

        for (int i = 0; i < secondLayerCount[currentWave]; i++)
        {
            switch (secondLayerEnemy[currentWave])
            {
                case EnemyTypes.berserker:
                    SpawnBerserker();
                    break;
                case EnemyTypes.chaser:
                    SpawnChaser();
                    break;
                case EnemyTypes.pulser:
                    SpawnPulser();
                    break;
                case EnemyTypes.trailer:
                    SpawnTrailer();
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1);
        }

        for (int i = 0; i < thirdLayerCount[currentWave]; i++)
        {
            switch (thirdLayerEnemy[currentWave])
            {
                case EnemyTypes.berserker:
                    SpawnBerserker();
                    break;
                case EnemyTypes.chaser:
                    SpawnChaser();
                    break;
                case EnemyTypes.pulser:
                    SpawnPulser();
                    break;
                case EnemyTypes.trailer:
                    SpawnTrailer();
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(1);
        }

        while (CurrentEnemyCount() > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(nextWaveDelay);
    }

    void SpawnBerserker()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(berserkerType, v, Quaternion.identity);
    }

    void SpawnChaser()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2,  Utility.screenHeight - 1), 0);

        Instantiate(chaserType, v, Quaternion.identity);
    }

    void SpawnPulser()
    {
        float xSpawn = UnityEngine.Random.Range( -Utility.screenWidth, Utility.screenWidth);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(pulserType, v, Quaternion.identity);
    }

    void SpawnTrailer()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth, Utility.screenWidth);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(trailerType, v, Quaternion.identity);
    }

    int CurrentEnemyCount()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");
        return g.Length;
    }
}