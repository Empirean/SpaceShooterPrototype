using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class DirectionalWeapon : MonoBehaviour
{
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

    Weapon weapon;
    float fireCounter;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        fireCounter = Time.time + primaryRateOfFire;
    }

    void FixedUpdate()
    {
        if (Time.time >= fireCounter)
        {
            StartCoroutine("ShootingController");

            fireCounter = Time.time + primaryRateOfFire;
        }
    }

    IEnumerator ShootingController()
    {

        for (int i = 0; i < secondaryTurretCount; i++)
        {

            float temp_angle = weapon.GetStartingAngle(primaryTurretCount, spread);
            float temp_offset = weapon.GetStartingOffset(primaryTurretCount, offset);

            temp_angle = isInverted ? temp_angle + 180 : temp_angle;
            temp_offset = isInverted ? temp_offset * -1 : temp_offset;

            for (int j = 0; j < primaryTurretCount; j++)
            {

                weapon.Shoot(temp_angle, temp_offset, speed);

                temp_angle += spread;
                temp_offset += isInverted ? offset : -offset;

            }

            yield return new WaitForSeconds(secondaryRateOfFire);
        }

    }

}
