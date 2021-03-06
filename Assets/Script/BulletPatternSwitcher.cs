﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternSwitcher : MonoBehaviour
{
    [Header("Pattern Timings")]
    public int patternCount;
    public float initialDelay;
    public List<float> patternDuration;

    [Space]
    [Header("Patterns and Idex")]
    public int patternGroupCount;
    public List<int> patternIndex;
    public List<GameObject> bulletSource;
    

    float patternCounter;
    int currentIndex = 0;

    void Start()
    {
        patternCounter = Time.time + initialDelay;

        enableTriggers(-1, false);

    }

    void Update()
    {
        if (Time.time > patternCounter)
        {
            
            patternCounter = Time.time + patternDuration[currentIndex];
            enableTriggers(currentIndex, true);
            currentIndex = (currentIndex + 1) % patternCount;
        }
    }

    void enableTriggers(int in_index, bool in_enabled)
    {
        for (int i = 0; i < patternGroupCount; i++)
        {
            bulletSource[i].SetActive(false);
        }

        if (in_index >= 0)
            bulletSource[in_index].SetActive(in_enabled);
    }
    
}
