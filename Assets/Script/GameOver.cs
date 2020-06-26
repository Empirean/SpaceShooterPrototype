using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;

    Player player;
    SpawnerMaster spawner;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.OnPlayerDeath += OnGameOver;

        spawner = GetComponent<SpawnerMaster>();
        spawner.OnPlayerWin += OnPlayerWin;
    }

    void OnGameOver()
    {
        loseScreen.SetActive(true);

    }

    void OnPlayerWin()
    {
        winScreen.SetActive(true);
    }
}
