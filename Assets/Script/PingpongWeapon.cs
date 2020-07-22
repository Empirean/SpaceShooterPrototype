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
    public List<float> startSpeed;
    public List<float> endSpeed;
    public List<float> startOffset;
    public List<float> endOffset;

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

            float t_startSpeed = startSpeed[i];
            float t_endSpeed = endSpeed[i];

            weapon.Shoot(Mathf.Lerp(t_startSpread, t_endSpread, (float)j / bulletCount[i]), 
                         Mathf.Lerp(t_startOffset, t_endOffset, (float)j / bulletCount[i]), 
                         Mathf.Lerp(t_startSpeed, t_endSpeed, (float)j / bulletCount[i]));
            
            yield return new WaitForSeconds(secondaryRateOfFire);
        }
        
        for (int k = halfBulletCount + 1; k <= bulletCount[i]; k++)
        {
            float t_startSpread = isInverted ? endSpread[i] + 180 : endSpread[i];
            float t_endSpread = isInverted ? startSpread[i] + 180 : startSpread[i]; 

            float t_startOffset = endOffset[i];
            float t_endOffset = startOffset[i]; 

            float t_startSpeed = endSpeed[i];
            float t_endSpeed = startSpeed[i]; 

            weapon.Shoot(Mathf.Lerp(t_startSpread, t_endSpread, (float)k / bulletCount[i]),
                         Mathf.Lerp(t_startOffset, t_endOffset, (float)k / bulletCount[i]),
                         Mathf.Lerp(t_startSpeed, t_endSpeed, (float)k / bulletCount[i]));

            yield return new WaitForSeconds(secondaryRateOfFire);
        }
 
    }

}
