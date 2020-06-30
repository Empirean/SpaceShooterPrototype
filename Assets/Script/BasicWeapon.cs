using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{

    [Header("Objects")]
    public Projectile projectile;
    public Transform spawnPoint;

    [Space]
    [Header("Weapon Properties")]
    public int primaryTurretCount = 3;
    public int secondaryTurretCount = 1;
    public float primaryRateOfFire = 1f;
    public float secondaryRateOfFire = 0.1f;
    public float spread;
    public float speed;
    public float offset;
    public float damage = 1;
    public string damageTag = "Enemy";
    public float maxRange = 15;


    [Space]
    [Header("Weapon Modes")]
    public bool isInverted = false;

    float fireCounter;

    public void Shoot(float in_Spread, float in_Offset, float in_Speed)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.Euler(0, 0, in_Spread)) as Projectile;

        bullet.SetSpeed(in_Speed);
        bullet.SetDamage(damage);
        bullet.SetDamageTag(damageTag);
        bullet.SetMaxRange(maxRange);
    }

    IEnumerator ShootingController()
    {

        for (int i = 0; i < secondaryTurretCount; i++)
        {

            float temp_angle = GetStartingAngle(primaryTurretCount, spread);
            float temp_offset = GetStartingOffset(primaryTurretCount, offset);
            
            temp_angle = isInverted ? temp_angle + 180 : temp_angle;
            temp_offset = isInverted ? temp_offset * -1 : temp_offset;
            
            for (int j = 0; j < primaryTurretCount; j++)
            {
                
                Shoot(temp_angle, temp_offset, speed);

                temp_angle += spread;
                temp_offset += isInverted ? offset : -offset;
                
            }

            yield return new WaitForSeconds(secondaryRateOfFire);
        }

    }

    public void Fire()
    {
        if (Time.time >= fireCounter)
        {
            StartCoroutine("ShootingController");

            fireCounter = Time.time + primaryRateOfFire;
        }
    }

    bool GetPlayerPosition(ref Vector3 in_position)
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");

        if (player.Length == 0)
        {
            in_position = Vector3.zero;
            return false;
        }
        in_position = player[0].transform.position;
        return true;
    }

    bool GetPlayerPosition()
    {
        Vector3 v = new Vector3();

        return GetPlayerPosition(ref v);
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

}
