using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Projectile projectile;
    public Transform spawnPoint;

    [Space]
    [Header("Weapon Properties")]

    [Range(1, 12)]
    public int mainTurretCount = 3;

    [Range(1, 10)]
    public int secondaryTurretCount = 1;

    public int shotsUntilBarrage = 8;

    [Range(0.15f, 6)]
    public float mainRateOfFire = 0.50f;

    [Range(0.01f, 0.15f)]
    public float secondaryRateOfFire = 0.1f;

    [Range(-180, 180)]
    public float spread = 15;
    [Range(0.2f, 6)]
    public float offset = 0;
    [Range(1, 10)]
    public float speed = 10;

    float fireCounter;


    [Space]
    [Header("Barrage Properties")]

    

    public int layers = 1;
    public List<float> startSpread;
    public List<float> endSpread;
    public List<float> startSpeed;
    public List<float> endSpeed;
    public List<float> startOffset;
    public List<float> endOffset;
    public List<int> bulletCount;

    float barrageDelay = 0.1f;
    int barrageCounter;

    
    void FixedUpdate()
    {
        if (Time.time >= fireCounter)
        {
            StartCoroutine("FireController");
            
            barrageCounter++;

            if (barrageCounter == shotsUntilBarrage)
            {
                barrageCounter = barrageCounter % shotsUntilBarrage;
                for (int i = 0; i < layers; i++)
                {

                    StartCoroutine("BarrageController", i);
                }
            }

            fireCounter = Time.time + mainRateOfFire;
        }

    }
    

    void Shoot(float newSpread, float newOffset, float in_speed)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(newOffset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.Euler(0, 0, newSpread)) as Projectile;
        bullet.SetSpeed(in_speed);
    }

    float GetStartingAngle(int in_TurretCount, float in_spread)
    {
        float in_startAngle = 0;

        for (int i = 0; i < in_TurretCount / 2; i++)
        {
            in_startAngle -= in_spread;
        }

        if (in_TurretCount % 2 == 0)
        {
            in_startAngle += in_spread / 2;
        }

        return in_startAngle;
    }

    float GetStartingOffset(int in_TurretCount, float in_offset)
    {
        float in_startOffset = 0;

        for (int i = 0; i < in_TurretCount / 2; i++)
        {
            in_startOffset += in_offset;
        }

        if (in_TurretCount % 2 == 0)
        {
            in_startOffset -= in_offset / 2;
        }

        return in_startOffset;
    }
    
    IEnumerator FireController()
    {

        for (int i = 0; i < secondaryTurretCount; i++)
        {
            float temp_angle = GetStartingAngle(mainTurretCount, spread);
            float temp_offset = GetStartingOffset(mainTurretCount, offset);

            for (int j = 0; j < mainTurretCount; j++)
            {
                
                Shoot(temp_angle, temp_offset, speed);
                temp_angle += spread;
                temp_offset -= offset;
            }

            yield return new WaitForSeconds(secondaryRateOfFire);
        }

    }

    IEnumerator BarrageController(int i)
    {

        for (int j = 0; j < bulletCount[i]; j++)
        {
            float t = ((float)j + 1) / (float)bulletCount[i];

            float newSpread = Mathf.Lerp(startSpread[i], endSpread[i], t);
            float newOffset = Mathf.Lerp(startOffset[i], endOffset[i], t);
            float newSpeed = Mathf.Lerp(startSpeed[i], endSpeed[i], t);

            Shoot(newSpread, newOffset, newSpeed);
            yield return new WaitForSeconds(barrageDelay);
        }

    }

}
