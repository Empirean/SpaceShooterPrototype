using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    SpawnerMaster spawnMaster;
    Upgradeable unit;
    int spawnCounter = 0;

    private void Start()
    {
        spawnMaster = GetComponent<SpawnerMaster>();
        spawnMaster.OnWaveEnd += OnWaveEnd;
        spawnMaster.OnWaveStart += OnWaveStart;

        unit = GameObject.FindGameObjectWithTag("Player").GetComponent<Upgradeable>();
    }

    public void SpawnRandomPowerup()
    {
        int r = Random.Range(0, 4);
        switch(r)
        {
            case 0: SpawnMainGunUpgrade();
                break;
            case 1: SpawnAuxillaryGunUpgrade();
                break;
            case 2: SpawnBarrageUpgrade();
                break;
            case 3: SpawnHealUpgrade();
                break;
            default:
                break;
        }
    }

    public void SpawnOffensivePowerup()
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                SpawnMainGunUpgrade();
                break;
            case 1:
                SpawnAuxillaryGunUpgrade();
                break;
            case 2:
                SpawnBarrageUpgrade();
                break;
            default:
                break;
        }
    }

    void SpawnMainGunUpgrade()
    {
        Vector3 spawnPoint = spawnPoint = new Vector3(Random.Range(-Utility.screenWidth / 2, Utility.screenWidth / 2), Utility.screenHeight, 0);
        Instantiate(Utility.pow_mainGunUpgrade, spawnPoint, Quaternion.identity);
    }

    void SpawnAuxillaryGunUpgrade()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-Utility.screenWidth / 2, Utility.screenWidth / 2), Utility.screenHeight, 0);
        Instantiate(Utility.pow_auxillaryGunUpgrade, spawnPoint, Quaternion.identity);
    }

    void SpawnBarrageUpgrade()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-Utility.screenWidth / 2, Utility.screenWidth / 2), Utility.screenHeight, 0);
        Instantiate(Utility.pow_barrageUpgrade, spawnPoint, Quaternion.identity);
    }

    void SpawnHealUpgrade()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-Utility.screenWidth / 2, Utility.screenWidth / 2), Utility.screenHeight, 0);
        Instantiate(Utility.pow_healUpgrade, spawnPoint, Quaternion.identity);
    }

    void OnWaveEnd()
    {
        if (spawnCounter < 3)
        {
            if (unit.GetCurrentFirepowerIndex() < 2)
                SpawnOffensivePowerup();
            else
                SpawnRandomPowerup();
        }
        else
        {
            SpawnHealUpgrade();
        }
        spawnCounter++;
    }

    void OnWaveStart()
    {
        int t_currentLevel = PlayerPrefs.GetInt(Utility.key_CurrentLevel, 1);
        int t_retryCount = PlayerPrefs.GetInt(Utility.key_RetryCount, 0);

        if (t_currentLevel >= Utility.cb_basicComebackLevel && t_retryCount > Utility.cb_retriesBeforeComeback)
        {
            SpawnMainGunUpgrade();
        }

        if (t_currentLevel >= Utility.cb_advancedComebackLevel && t_retryCount > Utility.cb_retriesBeforeComeback)
        {
            SpawnBarrageUpgrade();
        }
    }
}
