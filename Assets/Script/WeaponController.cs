using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class WeaponController : MonoBehaviour
{

    Weapon weapon;

    void Start()
    {
        weapon = GetComponent<Weapon>();
        
    }

    void FixedUpdate()
    {

        weapon.Fire();

    }
}
