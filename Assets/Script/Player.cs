using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Unit))]
public class Player : MonoBehaviour
{
    public event Action OnPlayerDeath;

    [Space]
    [Header("Upgrades")]

    [Header("Orbiters")]
    public int maxOrbiters = 2;
    public Transform orbiterType;
    public List<Transform> orbiterSlots;

    [Header("Heal")]
    public float healAmount = 5;

    [Header("Turret Upgrades")]
    public DirectionalWeapon dirWeapon;
    public int maxWeaponUpgrade = 3;
    public List<int> primaryTurretUpgrade;
    public List<int> secondaryTurretUpgrade;
    public List<float> offsetUpgrade;
    public List<float> spreadUpgrade;

    [Header("Missle Upgrade")]
    public DirectionalWeapon misWeapon;
    public int maxMissleUpgrade = 2;
    public List<int> missleUpgrade;

    Unit unit;

    int orbiterCount = 0;
    int turretCount = 0;
    int missleCount = 0;


    
    void Start()
    {
        unit = GetComponent<Unit>();
        LoadPlayerUpgrades();
    }

    void LoadPlayerUpgrades()
    {
        unit.SetHealth(PlayerPrefs.GetFloat(Utility.keyPlayerHealth, unit.maxHealth), unit.maxHealth);

        for (int i = 0; i < PlayerPrefs.GetInt(Utility.keyTurretLevel,0); i++)
        {
            WeaponUpgrade();
        }

        for (int i = 0; i < PlayerPrefs.GetInt(Utility.keyMissleLevel, 0); i++)
        {
            MissleUpgrade();
        }

        for (int i = 0; i < PlayerPrefs.GetInt(Utility.keyOrbiterLevel, 0); i++)
        {
            SpawnOrbiters();
        }
    }

    public void Move(Vector3 velocity)
    {
        transform.Translate((velocity * unit.speed) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (OnPlayerDeath != null && unit.currentHealth <= 0)
        {
            if (OnPlayerDeath != null) OnPlayerDeath();
        }
    }

    public void SpawnOrbiters()
    {
        if (orbiterCount < maxOrbiters)
        {
            Transform orbiter = Instantiate(orbiterType, orbiterSlots[orbiterCount].transform.position, Quaternion.identity) as Transform;
            orbiter.parent = orbiterSlots[orbiterCount];
            orbiterCount = orbiterCount + 1;
        }
    }

    public void Heal()
    {
        unit.Heal(healAmount);
    }

    public void WeaponUpgrade()
    {
        if (turretCount < maxWeaponUpgrade)
        {
            dirWeapon.primaryTurretCount = primaryTurretUpgrade[turretCount];
            dirWeapon.secondaryTurretCount = secondaryTurretUpgrade[turretCount];
            dirWeapon.offset = offsetUpgrade[turretCount];
            dirWeapon.spread = spreadUpgrade[turretCount];

            turretCount = Mathf.Clamp(turretCount + 1, 0, maxWeaponUpgrade);

        }
    }

    public void MissleUpgrade()
    {
        if (missleCount < maxMissleUpgrade)
        {
            misWeapon.primaryTurretCount = missleUpgrade[missleCount];

            missleCount = Mathf.Clamp(missleCount + 1, 0, maxMissleUpgrade);
        }
    }

    public float GetPlayerHealth()
    {
        return unit.currentHealth;
    }

    public int GetTurretLevel()
    {
        return turretCount;
    }

    public int GetMissleLevel()
    {
        return missleCount;
    }

    public int GetOrbiterLevel()
    {
        return orbiterCount;
    }

}
