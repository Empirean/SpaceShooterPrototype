using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    public PowerUp turretUpgrade;
    public PowerUp orbiterUpgrade;
    public PowerUp missleUpgrade;
    public PowerUp healUpgrade;

    Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = new Vector3(0, Utility.screenHeight, 0);
    }

    public void SpawnRandomPowerup()
    {
        int r = Random.Range(0, 4);
        switch(r)
        {
            case 0: SpawnTurretUpgrade();
                break;
            case 1: SpawnMissleUpgrade();
                break;
            case 2: SpawnOrbiterUpgrade();
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
                SpawnTurretUpgrade();
                break;
            case 1:
                SpawnMissleUpgrade();
                break;
            case 2:
                SpawnOrbiterUpgrade();
                break;
            default:
                break;
        }
    }

    public void SpawnTurretUpgrade()
    {
        Instantiate(turretUpgrade, spawnPoint, Quaternion.identity);
    }

    public void SpawnMissleUpgrade()
    {
        Instantiate(missleUpgrade, spawnPoint, Quaternion.identity);
    }

    public void SpawnOrbiterUpgrade()
    {
        Instantiate(orbiterUpgrade, spawnPoint, Quaternion.identity);
    }

    public void SpawnHealUpgrade()
    {
        Instantiate(healUpgrade, spawnPoint, Quaternion.identity);
    }
}
