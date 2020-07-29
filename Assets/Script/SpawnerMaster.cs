using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(PowerUpSpawner))]
public class SpawnerMaster : MonoBehaviour
{
    public event Action OnPlayerWin;
    public event Action OnLevelShow;
    public event Action OnLevelHide;
    public event Action OnBossSpawn;
    public event Action OnBossDeath;

    [Header("Enemy Prefabs")]
    public Unit pingerType;
    public Unit chaserType;
    public Unit pulserType;
    public Unit trailerType;
    public Unit vexerType;
    public Unit dividerType;
    public Unit breakerType;
    public Unit emitterType;
    public Unit defenderType;


    [Space]
    [Header("Bosses")]
    public Unit hydraType;
    public Unit cyclopsType;
    public Unit centaurType;
    public Unit manticoreType;
    public Unit demigodType;

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
        none,
        vexer,
        chaser,
        pulser,
        trailer,
        pinger,
        divider,
        breaker,
        emitter,
        defender,
        hydra,
        cyclops,
        centaur,
        manticore,
        demigod
    }

    [Space]
    [Header("Enemy Layers")]
    public EnemyTypes[] firstLayerEnemy;
    public EnemyTypes[] secondLayerEnemy;
    public EnemyTypes[] thirdLayerEnemy;

    int currentWave;

    PowerUpSpawner powerUpSpawner;

    private void Start()
    {
        powerUpSpawner = GetComponent<PowerUpSpawner>();
        StartCoroutine("SpawnSequence");
    }

    IEnumerator SpawnSequence()
    {
        if (OnLevelShow != null)
        {
            OnLevelShow();
        }

        yield return new WaitForSeconds(3);

        if (OnLevelHide != null)
        {
            OnLevelHide();
        }

        yield return new WaitForSeconds(1);

        for (currentWave = 0; currentWave < waveCount; currentWave++)
        {
            yield return StartCoroutine("SpawnCurrentWave");

            powerUpSpawner.SpawnRandomPowerup();
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

            SpawnChooser(firstLayerEnemy[currentWave]);
            
            yield return new WaitForSeconds(1);
        }


        for (int i = 0; i < secondLayerCount[currentWave]; i++)
        {
            SpawnChooser(secondLayerEnemy[currentWave]);

            yield return new WaitForSeconds(1);
        }


        for (int i = 0; i < thirdLayerCount[currentWave]; i++)
        {
            SpawnChooser(thirdLayerEnemy[currentWave]);

            yield return new WaitForSeconds(1);
        }

        while (CurrentEnemyCount() > 0)
        {
            yield return null;
        }

        yield return new WaitForSeconds(nextWaveDelay);
    }

    void SpawnChooser(EnemyTypes in_type)
    {
        switch (in_type)
        {
            case EnemyTypes.pinger:
                SpawnPinger();
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
            case EnemyTypes.vexer:
                SpawnVexer();
                break;
            case EnemyTypes.hydra:
                SpawnHydra();
                break;
            case EnemyTypes.cyclops:
                SpawnCyclops();
                break;
            case EnemyTypes.centaur:
                SpawnCentaur();
                break;
            case EnemyTypes.manticore:
                SpawnManticore();
                break;
            case EnemyTypes.demigod:
                SpawnDemigod();
                break;
            case EnemyTypes.divider:
                SpawnDivider();
                break;
            case EnemyTypes.breaker:
                SpawnBreaker();
                break;
            case EnemyTypes.emitter:
                SpawnEmitter();
                break;
            case EnemyTypes.defender:
                SpawnDefender();
                break;
            default:
                break;
        }
    }

    void SpawnHydra()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit hydra  = Instantiate(hydraType, v, Quaternion.identity);
        hydra.OnBossDeath += OnBossDestroy;
    }

    void SpawnCyclops()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight / 2, 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit cyclops = Instantiate(cyclopsType, v, Quaternion.identity);
        cyclops.OnBossDeath += OnBossDestroy;
    }

    void SpawnCentaur()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 8, Utility.screenHeight - 1), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit centaur = Instantiate(centaurType, v, Quaternion.identity);
        centaur.OnBossDeath += OnBossDestroy;
    }

    void SpawnManticore()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 8, Utility.screenHeight - 1), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit manticore = Instantiate(manticoreType, v, Quaternion.identity);
        manticore.OnBossDeath += OnBossDestroy;
    }

    void SpawnDemigod()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 8, Utility.screenHeight - 1), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit demigod = Instantiate(demigodType, v, Quaternion.identity);
        demigod.OnBossDeath += OnBossDestroy;

    }

    void SpawnPinger()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(pingerType, v, Quaternion.identity);
    }

    void SpawnBreaker()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(breakerType, v, Quaternion.identity);
    }

    void SpawnVexer()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(vexerType, v, Quaternion.identity);
    }

    void SpawnChaser()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2,  Utility.screenHeight - 1), 0);

        Instantiate(chaserType, v, Quaternion.identity);
    }

    void SpawnEmitter()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight - 1), 0);

        Instantiate(emitterType, v, Quaternion.identity);
    }

    void SpawnPulser()
    {
        float xSpawn = UnityEngine.Random.Range( -Utility.screenWidth / 2, Utility.screenWidth / 2);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(pulserType, v, Quaternion.identity);
    }

    void SpawnTrailer()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth, Utility.screenWidth);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(trailerType, v, Quaternion.identity);
    }

    void SpawnDivider()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth /2 , Utility.screenWidth /2);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(dividerType, v, Quaternion.identity);
    }

    void SpawnDefender()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth / 2, Utility.screenWidth / 2);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(defenderType, v, Quaternion.identity);
    }

    int CurrentEnemyCount()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");
        return g.Length;
    }

    void OnBossDestroy()
    {
        if (OnBossDeath != null) OnBossDeath();
    }
}
