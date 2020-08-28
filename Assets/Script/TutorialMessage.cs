using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    public GameObject message;
    public float messageDuration;
    
    SpawnerMaster spawnMaster;
    float messageCounter;
    bool notified = false;

    void Start()
    {
        spawnMaster = GetComponent<SpawnerMaster>();
        spawnMaster.OnWaveEnd += OnwaveEnd;
    }

    void Update()
    {
        if (Time.time > messageCounter && message.activeSelf)
        {
            message.SetActive(false);
        }
    }

    void OnwaveEnd()
    {
        if (!notified)
        {
            message.SetActive(true);
            messageCounter = messageDuration + Time.time;
            notified = true;
        }
    }
}
