using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class HomingWeapon : MonoBehaviour
{
    [Space]
    [Header("Weapon Properties")]
    public int primaryTurretCount = 3;
    public float primaryRateOfFire = 1f;
    public float secondaryRateOfFire = 0.1f;
    public float speed;
    public float offset;
    public float initialDelay;

    [Space]
    [Header("Weapon Modes")]
    public bool isInverted = false;

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
            StartCoroutine("HomingController");

            fireCounter = Time.time + primaryRateOfFire;
        }
    }

    IEnumerator HomingController()
    {

        for (int i = 0; i < primaryTurretCount; i++)
        {
            Vector3 v = new Vector3();
            if ( weapon.GetPlayerPosition(ref v))
            {
                weapon.Shoot(v, offset, speed);
            }
            else
            {
                weapon.Shoot(isInverted == true ? 180 : 0, offset, speed);
            }

            
            yield return new WaitForSeconds(secondaryRateOfFire);
        }

    }

}

    
