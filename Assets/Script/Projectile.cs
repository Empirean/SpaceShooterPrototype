using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float startSpeed;
    float endSpeed;
    float damage = 1;
    float maxRange = 10;
    float currentRange = 0;
    float boostDelay = 0;
    float boostCounter;

    bool isPenetrating = false;

    string damageTag = "Enemy";

    Weapon.WeaponTypes damageType;

    private void Start()
    {
        boostCounter = Time.time + boostDelay;
    }

    void FixedUpdate()
    {
        if (Time.time > boostCounter)
        {
            Move();
            if (!CheckRange()) Destroy(gameObject);
        }
    }

    public void SetStartSpeed(float in_speed)
    {
        startSpeed = in_speed;
    }

    public void SetEndSpeed(float in_speed)
    {
        endSpeed = in_speed;
    }

    public void SetDamage(float in_damage)
    {
        damage = in_damage;
    }

    public void SetMaxRange(float in_range)
    {
        maxRange = in_range;
    }

    public void SetBoostDelay(float in_delay)
    {
        boostDelay = in_delay;
        boostCounter = Time.time + boostDelay;
    }

    public void SetDamageTag(string in_damageTag)
    {
        damageTag = in_damageTag;
        
    }

    public void SetDamageType(Weapon.WeaponTypes in_damageType)
    {
        damageType = in_damageType;
        if (in_damageType == Weapon.WeaponTypes.piercing)
            isPenetrating = true;
    }

    void Move()
    {
        transform.Translate(Vector3.up * Mathf.Lerp(startSpeed, endSpeed, currentRange/maxRange) * Time.deltaTime);
    }

    bool CheckRange()
    {
        if (currentRange < maxRange)
        {
            currentRange = currentRange + (Mathf.Lerp(startSpeed, endSpeed, currentRange / maxRange) * Time.deltaTime);
            return true;
        }
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == damageTag)
        {
            if (isPenetrating)
                isPenetrating = false;
            else
                Destroy(gameObject);

            GameObject explosionEffectType;
            if (damageType == Weapon.WeaponTypes.normal)
            {
                explosionEffectType = Utility.vfx_hitNormal;
            }
            else if (damageType == Weapon.WeaponTypes.piercing)
            {
                explosionEffectType = Utility.vfx_hitPiercing;
            }
            else if (damageType == Weapon.WeaponTypes.heavy)
            {
                float chance = .5f;
                
                if (Random.Range(0f, 100f) >= chance) damage = damage * 2;

                explosionEffectType = Utility.vfx_hitheavy;
            }
            else
            {
                explosionEffectType = Utility.vfx_hitNormal;
            }

            Unit unit = other.GetComponent<Unit>();
            unit.Damage(damage, damageType);

            GameObject effects = Instantiate(explosionEffectType, gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(effects, Utility.vfx_effectDuration);
        }
    }
}
