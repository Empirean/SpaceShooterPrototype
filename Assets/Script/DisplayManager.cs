using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject lvlScreen;
    public GameObject bossHealth;

    FleetManager fleetManager;
    SpawnerMaster spawner;
    bool isGameOver = false;

    private void Start()
    {
        fleetManager = GetComponent<FleetManager>();
        fleetManager.OnGameOver += OnGameOver;

        spawner = GetComponent<SpawnerMaster>();
        spawner.OnPlayerWin += OnPlayerWin;
        spawner.OnLevelShow += OnLevelShow;
        spawner.OnLevelHide += OnLevelHide;
        spawner.OnBossSpawn += OnBossSpawn;
        spawner.OnBossDeath += OnBossDeath;
    }

    void OnBossSpawn()
    {
        bossHealth.SetActive(true);
    }

    void OnBossDeath()
    {
        bossHealth.SetActive(false);
    }

    void OnGameOver()
    {
        if (!isGameOver)
        {

            loseScreen.SetActive(true);
            isGameOver = true;
        }
    }

    void OnPlayerWin()
    {
        if (!isGameOver)
        {
            winScreen.SetActive(true);
            isGameOver = true;
        }

    }

    void OnLevelShow()
    {
        lvlScreen.SetActive(true);
    }

    void OnLevelHide()
    {
        lvlScreen.SetActive(false);
    }
}
