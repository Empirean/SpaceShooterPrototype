using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;
    public GameObject lvlScreen;

    Player player;
    SpawnerMaster spawner;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += OnGameOver;

        spawner = GetComponent<SpawnerMaster>();
        spawner.OnPlayerWin += OnPlayerWin;
        spawner.OnLevelShow += OnLevelShow;
        spawner.OnLevelHide += OnLevelHide;
    }

    void OnGameOver()
    {
        loseScreen.SetActive(true);
        gameObject.SetActive(false);

    }

    void OnPlayerWin()
    {
        winScreen.SetActive(true);
        gameObject.SetActive(false);
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
