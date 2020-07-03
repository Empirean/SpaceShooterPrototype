using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Objects")]
    public Projectile projectile;
    public Transform spawnPoint;
    
    [Space]
    [Header("Weapon Properties")]
    public float damage = 1;
    public string damageTag = "Enemy";
    public float maxRange = 15;

    public void Shoot(float in_Spread, float in_Offset, float in_Speed)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.Euler(0, 0, in_Spread)) as Projectile;

        bullet.SetSpeed(in_Speed);
        bullet.SetDamage(damage);
        bullet.SetDamageTag(damageTag);
        bullet.SetMaxRange(maxRange);
    }

    public void Shoot(Vector3 in_target, float in_Offset, float in_Speed)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.identity) as Projectile;

        bullet.transform.LookAt(in_target);
        bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x + 90, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);
        bullet.SetSpeed(in_Speed);
        bullet.SetDamage(damage);
        bullet.SetDamageTag(damageTag);
        bullet.SetMaxRange(maxRange);
    }

    public bool GetPlayerPosition(ref Vector3 in_position)
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

    public float GetStartingAngle(int in_TurretCount, float in_spread)
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

    public float GetStartingOffset(int in_TurretCount, float in_offset)
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
