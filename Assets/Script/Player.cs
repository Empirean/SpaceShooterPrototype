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

    int orbiterCount;
    int upgradeCount = 0;
    int misslecount = 0;


    
    void Start()
    {
        unit = GetComponent<Unit>();
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
        dirWeapon.primaryTurretCount = primaryTurretUpgrade[upgradeCount];
        dirWeapon.secondaryTurretCount = secondaryTurretUpgrade[upgradeCount];
        dirWeapon.offset = offsetUpgrade[upgradeCount];
        dirWeapon.spread = spreadUpgrade[upgradeCount];

        upgradeCount = Mathf.Clamp(upgradeCount + 1, 0, maxWeaponUpgrade - 1);
    }

    public void MissleUpgrade()
    {
        misWeapon.primaryTurretCount = missleUpgrade[misslecount];

        misslecount = Mathf.Clamp(misslecount + 1, 0, maxMissleUpgrade - 1);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnOrbiters();
        }

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Heal();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            WeaponUpgrade();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            MissleUpgrade();
        }
    }


}
