using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCoordinator : MonoBehaviour
{
    [Header("Pattern Count and Delay")]
    public float patternInitialDelay;
    public int patternCount;

    [Space]
    [Header("Pattern groups and index")]
    public List<MonoBehaviour> patternGroup;
    public List<int> patternIndex;
    public List<float> patternCycleDelay;

    float patternCycleCounter;
    int patternCurrentIndex = 0;

    private void Start()
    {
        patternCycleCounter = Time.time + patternInitialDelay;

        foreach (var item in patternGroup)
        {
            item.enabled = false;
        }
    }

    void Update()
    {
        if (Time.time > patternCycleCounter)
        {
            patternCycleCounter = Time.time + patternCycleDelay[patternCurrentIndex];
            EnableGroup(patternCurrentIndex);
            patternCurrentIndex = (patternCurrentIndex + 1) % (patternIndex[patternIndex.Count - 1] + 1);
            
        }
    }

    void EnableGroup(int groupNumber)
    {
        for (int i = 0; i < patternCount; i++)
        {
            patternGroup[i].enabled = false;
            if (patternIndex[i] == groupNumber) patternGroup[i].enabled = true; 
        }
    }
}
