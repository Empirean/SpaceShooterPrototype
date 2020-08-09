using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class DirectedBarrage : MonoBehaviour
{

    [Space]
    [Header("Weapon Properties")]
    public int primaryTurretCount;
    public int secondaryTurretCount;
    public float primaryRateOfFire;
    public float secondaryRateOfFire;
    public float startSpeed;
    public float endSpeed;
    public float spread;
    public float boostDelay;
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
            StartCoroutine("ShootingController");

            fireCounter = Time.time + primaryRateOfFire;
        }
    }

    private void OnEnable()
    {
        fireCounter = Time.time + initialDelay;
    }

    IEnumerator ShootingController()
    {

        Vector3 v = new Vector3();
        bool isPlayer = weapon.GetPlayerPosition(ref v);
        
        for (int i = 0; i < secondaryTurretCount; i++)
        {
            float temp_angle = weapon.GetStartingAngle(primaryTurretCount, spread);

            for (int j = 0; j < primaryTurretCount; j++)
            {

                if (isPlayer && v.x != transform.position.x)
                {
                    weapon.Shoot(v, temp_angle, 0, startSpeed, endSpeed, boostDelay);
                }
                else
                {
                    weapon.Shoot(isInverted == true ? temp_angle + 180 : temp_angle, 0, startSpeed, endSpeed, boostDelay);
                }

                temp_angle += spread;

            }

            yield return new WaitForSeconds(secondaryRateOfFire);
        }
    }
}
