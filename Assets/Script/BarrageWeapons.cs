﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class BarrageWeapons : MonoBehaviour
{
    [Space]
    [Header("Weapon Properties")]
    public int layers = 2;
    public float primaryRateOfFire = 1f;
    public float secondaryRateOfFire = 0.1f;
    public float initialDelay;

    [Space]
    public List<int> bulletCount;
    public List<float> startSpread;
    public List<float> endSpread;
    public List<float> startSpeed;
    public List<float> endSpeed;
    public List<float> startOffset;
    public List<float> endOffset;

    [Space]
    [Header("Weapon Modes")]
    public bool isInverted = false;

    Weapon weapon;
    float fireCounter;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        fireCounter = Time.time + initialDelay;
    }

    void Update()
    {
        if (Time.time >= fireCounter)
        {
            StartCoroutine("BarrageController");

            fireCounter = Time.time + primaryRateOfFire;
        }
    }

    IEnumerator BarrageController()
    {
        
        for (int i = 0; i < layers; i++)
        {

            StartCoroutine("BarrageCoroutine", new object[1] { i});
            
        }
        yield return null;
    }

    IEnumerator BarrageCoroutine(object[] param)
    {
        int i = (int)param[0];

        for (int j = 0; j < bulletCount[i]; j++)
        {

            float t_startSpread = isInverted ? startSpread[i] + 180 : startSpread[i];
            float t_endSpread = isInverted ? endSpread[i] + 180 : endSpread[i];


            weapon.Shoot(Mathf.Lerp(t_startSpread, t_endSpread, (float) j / bulletCount[i]),
                            Mathf.Lerp(startOffset[i], endOffset[i], (float) j / bulletCount[i]),
                            Mathf.Lerp(startSpeed[i], endSpeed[i], (float) j / bulletCount[i]));

            yield return new WaitForSeconds(secondaryRateOfFire);
        }
    }
}
