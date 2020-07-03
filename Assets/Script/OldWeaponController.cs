using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OldWeapon))]
public class OldWeaponController : MonoBehaviour
{

    OldWeapon weapon;

    void Start()
    {
        weapon = GetComponent<OldWeapon>();
        
    }

    void FixedUpdate()
    {

        weapon.Fire();

    }
}
