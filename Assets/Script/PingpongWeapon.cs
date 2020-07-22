using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PingpongWeapon : MonoBehaviour
{
    [Header("Weapon Properties")]
    public int layers;
    public float primaryRateOfFire;
    public float secondaryRateOfFire;
    public float initialDelay;

    [Space]
    public List<int> bulletCount;
    public List<float> startSpread;
    public List<float> endSpread;
    public List<float> startSpeed1;
    public List<float> startSpeed2;
    public List<float> endSpeed1;
    public List<float> endSpeed2;
    public List<float> startOffset;
    public List<float> endOffset;
    public List<float> startBoostDelay;
    public List<float> endBoostDelay;

    [Space]
    [Header("Weapon Modes")]
    public bool isInverted;

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
            StartCoroutine("PingpongController");

            fireCounter = Time.time + primaryRateOfFire;
        }
    }

    IEnumerator PingpongController()
    {

        for (int i = 0; i < layers; i++)
        {
            StartCoroutine("PingpongCoroutine", new object[] { i });
        }

        yield return null;
    }

    IEnumerator PingpongCoroutine(object[] param)
    {
        int i = (int)param[0];
        int halfBulletCount = bulletCount[i] / 2;

        for (int j = 0; j < halfBulletCount; j++)
        {

            float t_startSpread = isInverted ? startSpread[i] + 180 : startSpread[i];
            float t_endSpread = isInverted ?  endSpread[i] + 180 : endSpread[i];

            float t_startOffset = startOffset[i];
            float t_endOffset = endOffset[i];

            float t_startSpeed1 = startSpeed1[i];
            float t_startSpeed2 = startSpeed2[i];

            float t_endSpeed1 = endSpeed1[i];
            float t_endSpeed2 = endSpeed2[i];

            float t_startBoostDelay = startBoostDelay[i];
            float t_endBoostDelay = endBoostDelay[i];

            weapon.Shoot(Mathf.Lerp(t_startSpread, t_endSpread, (float)j / bulletCount[i]), 
                         Mathf.Lerp(t_startOffset, t_endOffset, (float)j / bulletCount[i]), 
                         Mathf.Lerp(t_startSpeed1, t_startSpeed2, (float)j / bulletCount[i]),
                         Mathf.Lerp(t_endSpeed1, t_endSpeed2, (float)j / bulletCount[i]),
                         Mathf.Lerp(t_startBoostDelay, t_endBoostDelay, (float)j / bulletCount[i]));
            
            yield return new WaitForSeconds(secondaryRateOfFire);
        }
        
        for (int k = halfBulletCount + 1; k <= bulletCount[i]; k++)
        {
            float t_startSpread = isInverted ? endSpread[i] + 180 : endSpread[i];
            float t_endSpread = isInverted ? startSpread[i] + 180 : startSpread[i]; 

            float t_startOffset = endOffset[i];
            float t_endOffset = startOffset[i]; 

            float t_startSpeed1 = startSpeed2[i];
            float t_startSpeed2 = startSpeed1[i];

            float t_endSpeed1 = startSpeed2[i];
            float t_endSpeed2 = startSpeed1[i];

            float t_startBoostDelay = endBoostDelay[i];
            float t_endBoostDelay = startBoostDelay[i];

            weapon.Shoot(Mathf.Lerp(t_startSpread, t_endSpread, (float)k / bulletCount[i]),
                         Mathf.Lerp(t_startOffset, t_endOffset, (float)k / bulletCount[i]),
                         Mathf.Lerp(t_startSpeed1, t_startSpeed2, (float)k / bulletCount[i]),
                         Mathf.Lerp(t_endSpeed1, t_endSpeed2, (float)k / bulletCount[i]),
                         Mathf.Lerp(t_startBoostDelay, t_endBoostDelay, (float)k / bulletCount[i]));

            yield return new WaitForSeconds(secondaryRateOfFire);
        }
 
    }

}
