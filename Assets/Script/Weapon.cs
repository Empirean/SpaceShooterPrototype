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

    [Space]
    [Header("Weapon Switching")]
    public bool weaponSwitching = false;
    public float weaponSwitchDelay;
    public List<MonoBehaviour> mainWeapon;
    public List<MonoBehaviour> secondaryWeapon;

    float weaponSwitchCounter;
    int currentWeapon = 0;

    private void Update()
    {
        if (weaponSwitching)
        {
            if (Time.time >= weaponSwitchCounter)
            {

                if (currentWeapon == 0)
                {
                    enablePrimaryWeapon(true);
                    enableSecondaryWeapon(false);
                    currentWeapon = 1;
                }
                else
                {
                    enablePrimaryWeapon(false);
                    enableSecondaryWeapon(true);
                    currentWeapon = 0;
                }

                weaponSwitchCounter = Time.time + weaponSwitchDelay;
            }
        }
    }

    void enablePrimaryWeapon(bool in_mode)
    {
        foreach (MonoBehaviour item in mainWeapon)
        {
            item.enabled = in_mode;
        }
    }
    
    void enableSecondaryWeapon(bool in_mode)
    {
        foreach (MonoBehaviour item in secondaryWeapon)
        {
            item.enabled = in_mode;
        }
    }

    public void Shoot(float in_Spread, float in_Offset, float in_Speed)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.Euler(0, 0, in_Spread)) as Projectile;

        SetProjectileProperty(ref bullet, in_Speed);
    }

    public void Shoot(Vector3 in_Target, float in_Offset, float in_Speed)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.identity) as Projectile;

        bullet.transform.LookAt(in_Target);
        bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x + 90, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);

        SetProjectileProperty(ref bullet, in_Speed);
    }

    private void SetProjectileProperty(ref Projectile in_Projectile, float in_Speed)
    {
        in_Projectile.SetSpeed(in_Speed);
        in_Projectile.SetDamage(damage);
        in_Projectile.SetDamageTag(damageTag);
        in_Projectile.SetMaxRange(maxRange);
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
