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
        demigod,
        harpy,
        argus,
        gorgon,
        cerberus,
        minotaur
    }

    [Space]
    [Header("Enemy Layers")]
    public EnemyTypes[] firstLayerEnemy;
    public EnemyTypes[] secondLayerEnemy;
    public EnemyTypes[] thirdLayerEnemy;

    [Space]
    [Header("Come back")]
    public int minComebackThreshold = 2;
    public int advancedCombackThreshold = 7;
    public int retriesBeforeComeback = 0;
    public float combackDelay = 0.5f;

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

        int currentLevel = PlayerPrefs.GetInt(Utility.keyCurrentLevel, 1);
        int retryCount = PlayerPrefs.GetInt(Utility.keyRetryCount, 0);

        if (currentLevel > minComebackThreshold && retryCount > retriesBeforeComeback) 
        {
            powerUpSpawner.SpawnTurretUpgrade();
        }

        if (currentLevel > advancedCombackThreshold && retryCount > retriesBeforeComeback)
        {
            yield return new WaitForSeconds(combackDelay);

            powerUpSpawner.SpawnOrbiterUpgrade();
        }

        for (currentWave = 0; currentWave < waveCount; currentWave++)
        {
            yield return StartCoroutine("SpawnCurrentWave");

            if (currentWave == waveCount -1)
            {
                powerUpSpawner.SpawnHealUpgrade();
            }
            else
            {
                Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

                if (player.GetFirepowerIndex() < 3)
                {
                    powerUpSpawner.SpawnOffensivePowerup();
                }
                else
                {
                    powerUpSpawner.SpawnRandomPowerup();
                }
            }

            
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
            case EnemyTypes.harpy:
                SpawnHarpy();
                break;
            case EnemyTypes.argus:
                SpawnArgus();
                break;
            case EnemyTypes.gorgon:
                SpawnGorgon();
                break;
            case EnemyTypes.cerberus:
                SpawnCerberus();
                break;
            case EnemyTypes.minotaur:
                SpawnMinotaur();
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

        Unit hydra  = Instantiate(Utility.hydraType, v, Quaternion.identity);
        hydra.OnBossDeath += OnBossDestroy;
    }

    void SpawnGorgon()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit hydra = Instantiate(Utility.gorgonType, v, Quaternion.identity);
        hydra.OnBossDeath += OnBossDestroy;
    }

    void SpawnCerberus()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit hydra = Instantiate(Utility.cerberusType, v, Quaternion.identity);
        hydra.OnBossDeath += OnBossDestroy;
    }

    void SpawnMinotaur()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit hydra = Instantiate(Utility.minotaurType, v, Quaternion.identity);
        hydra.OnBossDeath += OnBossDestroy;
    }

    void SpawnCyclops()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight / 2, 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit cyclops = Instantiate(Utility.cyclopsType, v, Quaternion.identity);
        cyclops.OnBossDeath += OnBossDestroy;
    }

    void SpawnCentaur()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 8, Utility.screenHeight - 1), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit centaur = Instantiate(Utility.centaurType, v, Quaternion.identity);
        centaur.OnBossDeath += OnBossDestroy;
    }

    void SpawnManticore()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 8, Utility.screenHeight - 1), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit manticore = Instantiate(Utility.manticoreType, v, Quaternion.identity);
        manticore.OnBossDeath += OnBossDestroy;
    }

    void SpawnDemigod()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 8, Utility.screenHeight - 1), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit demigod = Instantiate(Utility.demigodType, v, Quaternion.identity);
        demigod.OnBossDeath += OnBossDestroy;

    }

    void SpawnHarpy()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit hydra = Instantiate(Utility.harpyType, v, Quaternion.identity);
        hydra.OnBossDeath += OnBossDestroy;
    }

    void SpawnArgus()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight / 2, 0);

        if (OnBossSpawn != null) OnBossSpawn();

        Unit cyclops = Instantiate(Utility.argusType, v, Quaternion.identity);
        cyclops.OnBossDeath += OnBossDestroy;
    }

    void SpawnPinger()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(Utility.pingerType, v, Quaternion.identity);
    }

    void SpawnBreaker()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(Utility.breakerType, v, Quaternion.identity);
    }

    void SpawnVexer()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight), 0);

        Instantiate(Utility.vexerType, v, Quaternion.identity);
    }

    void SpawnChaser()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2,  Utility.screenHeight - 1), 0);

        Instantiate(Utility.chaserType, v, Quaternion.identity);
    }

    void SpawnEmitter()
    {
        int rnd = UnityEngine.Random.Range(0, 2);

        float xSpawn = rnd == 0 ? -Utility.screenWidth : Utility.screenWidth;
        Vector3 v = new Vector3(xSpawn, UnityEngine.Random.Range(Utility.screenHeight / 2, Utility.screenHeight - 1), 0);

        Instantiate(Utility.emitterType, v, Quaternion.identity);
    }

    void SpawnPulser()
    {
        float xSpawn = UnityEngine.Random.Range( -Utility.screenWidth / 2, Utility.screenWidth / 2);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(Utility.pulserType, v, Quaternion.identity);
    }

    void SpawnTrailer()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth, Utility.screenWidth);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(Utility.trailerType, v, Quaternion.identity);
    }

    void SpawnDivider()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth /2 , Utility.screenWidth /2);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(Utility.dividerType, v, Quaternion.identity);
    }

    void SpawnDefender()
    {
        float xSpawn = UnityEngine.Random.Range(-Utility.screenWidth / 2, Utility.screenWidth / 2);
        Vector3 v = new Vector3(xSpawn, Utility.screenHeight, 0);

        Instantiate(Utility.defenderType, v, Quaternion.identity);
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
