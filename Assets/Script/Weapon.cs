using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Objects")]
    public Projectile projectile;
    public Transform spawnPoint;
    
    public enum WeaponTypes
    {
        normal,
        piercing,
        heavy
    };
    public WeaponTypes weaponType;

    [Space]
    [Header("Weapon Properties")]
    public float damage = 1;
    public string damageTag = "Enemy";
    public float maxRange = 15;

    public void Shoot(float in_Spread, float in_Offset, float in_StartSpeed, float in_EndSpeed, float in_BoostDelay)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);

        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.Euler(0, 0, in_Spread)) as Projectile;

        SetProjectileProperty(ref bullet, in_StartSpeed, in_EndSpeed, in_BoostDelay, weaponType);
    }

    public void Shoot(Vector3 in_Target, float in_Offset, float in_StartSpeed, float in_EndSpeed, float in_BoostDelay)
    {
        Shoot(in_Target, 0, in_Offset, in_StartSpeed, in_EndSpeed, in_BoostDelay);
    }

    public void Shoot(Vector3 in_Target, float in_Spread, float in_Offset, float in_StartSpeed, float in_EndSpeed, float in_BoostDelay)
    {
        Vector3 t_newOffset = spawnPoint.position + new Vector3(in_Offset, 0, 0);
        Projectile bullet = Instantiate(projectile, t_newOffset, Quaternion.identity) as Projectile;
        
        bullet.transform.LookAt(in_Target);
        bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x + 90 + in_Spread, bullet.transform.eulerAngles.y, bullet.transform.eulerAngles.z);

        SetProjectileProperty(ref bullet, in_StartSpeed, in_EndSpeed, in_BoostDelay, weaponType);
    }

    private void SetProjectileProperty(ref Projectile in_Projectile, float in_StartSpeed, float in_EndSpeed, float in_BoostDelay, Weapon.WeaponTypes in_damageType)
    {
        in_Projectile.SetStartSpeed(in_StartSpeed);
        in_Projectile.SetEndSpeed(in_EndSpeed);
        in_Projectile.SetDamage(damage);
        in_Projectile.SetDamageTag(damageTag);
        in_Projectile.SetMaxRange(maxRange);
        in_Projectile.SetBoostDelay(in_BoostDelay);
        in_Projectile.SetDamageType(in_damageType);
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

    public float GetStartingAngle(int in_TurretCount, float in_Spread)
    {
        float in_startAngle = 0;

        for (int i = 0; i < in_TurretCount / 2; i++)
        {
            in_startAngle -= in_Spread;
        }

        if (in_TurretCount % 2 == 0)
        {
            in_startAngle += in_Spread / 2;
        }

        return in_startAngle;
    }

    public float GetStartingAngle(Vector3 in_TargetPosition, int in_TurretCount, float in_Spread)
    {
        float t_angle = Vector3.SignedAngle(gameObject.transform.position, in_TargetPosition, Vector3.up);

        return t_angle;
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
