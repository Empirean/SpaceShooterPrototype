using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BasicWeapon))]
public class WeaponController : MonoBehaviour
{

    BasicWeapon weapon;

    void Start()
    {
        weapon = GetComponent<BasicWeapon>();
        
    }

    void FixedUpdate()
    {

        weapon.Fire();

    }
}
